using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO; 
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Operador_911
{

    public partial class FormOperador : Form
    {
        private GMapOverlay markerPatrullas;
        private GMapOverlay markerComisarias;
        private GMapOverlay markerHospitales;
        private GMapOverlay markerBomberos;
        private GMapOverlay markerAlertas;
        private GMapOverlay polygonOverlay;
        private GMapOverlay overlayRutas = new GMapOverlay("rutas");

        private bool jurisdiccionesVisibles = false;
        private bool bomberosVisibles = false;
        private bool hospitalesVisibles = false;
        private string patrullaSeleccionada = null;
        private int idPatrullaSeleccionada = 0;
        private string valorAnteriorPatrulla = null;
        private int ordenActual = 1;
        private string estadoAnterior = "";

        private List<Nodo> nodos = new List<Nodo>();
       

        PointLatLng origen;
        private List<PointLatLng> destinos = new List<PointLatLng>(); // Varias alertas
        
        public class Nodo
        {
            public double Lat { get; set; }
            public double Lng { get; set; }
            public List<(Nodo vecino, double distancia)> Vecinos { get; set; } = new List<(Nodo, double)>();
        }

        
        private Dictionary<string, Color> coloresDelitos = new Dictionary<string, Color>()
        {
            // Rojo (Emergencia)
            { "Abuso de armas", Color.Red },
            { "Abuso sexual", Color.Red },
            { "Asesinato", Color.Red },
            { "Asesinato en Progreso", Color.Red },
            { "Choque", Color.Red },
            { "Descompensación", Color.Red },
            { "Disparo de arma de fuego con herida", Color.Red },
            { "Disparo de arma de fuego y agresión en estado de emoción violenta", Color.Red },
            { "Encarcelación u otra privación grave de la libertad física", Color.Red },
            { "Explotación de Menores", Color.Red },
            { "Homicidio", Color.Red },
            { "Incendio", Color.Red },
            { "Intento de Homicidio", Color.Red },
            { "Intento de Suicidio", Color.Red },
            { "Motín", Color.Red },
            { "Prostitución forzada", Color.Red },
            { "Robo a mano armada", Color.Red },
            { "Robo en Progreso", Color.Red },
            { "Secuestro", Color.Red },
            { "Sustracción, retención y ocultamiento de menores", Color.Red },
            { "Trata de menores", Color.Red },
            { "Trata de mujeres", Color.Red },
            { "Usurpación con gente dentro", Color.Red },
            { "Violación", Color.Red },

            // Amarillo (Media)
            { "Amenazas", Color.Yellow },
            { "Contrabando de estupefacientes", Color.Yellow },
            { "Delitos contra el orden público", Color.Yellow },
            { "Delitos contra la seguridad pública", Color.Yellow },
            { "Delitos contra las personas", Color.Yellow },
            { "Disparo de arma de fuego sin herir", Color.Yellow },
            { "Entorpecimiento de transporte o servicio público", Color.Yellow },
            { "Insania", Color.Yellow },
            { "Lesiones", Color.Yellow },
            { "Resistencia a la autoridad", Color.Yellow },
            { "Riña", Color.Yellow },
            { "Robo", Color.Yellow },
            { "Solicitud Médica", Color.Yellow },
            { "Violación de domicilio", Color.Yellow },

            // Verde (Baja)
            { "Daños", Color.LightGreen },
            { "Desacato", Color.LightGreen },
            { "Lesiones leves", Color.LightGreen },
            { "Obstrucción de la vía pública", Color.LightGreen },
            { "Usurpación", Color.LightGreen },
            { "otros", Color.LightGreen }
        };

        public FormOperador()
        {
            InitializeComponent();

            textNombre.KeyPress += textNombre_KeyPress;
            textTelefono.KeyPress += textTelefono_KeyPress;
            textDireccion.KeyPress += textDireccion_KeyPress;


        }

        


        private void dataGridViewAlertas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridViewAlertas.Rows.Count; i++)
            {
                string tipoIncidente = dataGridViewAlertas.Rows[i].Cells["Incidente"].Value?.ToString() ?? "";
                PintarFila(i, tipoIncidente);
            }
        }

        private void FormOperador_Load_1(object sender, EventArgs e)
        {

            gMapControl1.Dock = DockStyle.Fill;

            // Panel navegación arriba
            panelNavegacion.Dock = DockStyle.Top;
            panelNavegacion.Height = 50;
            panelNavegacion.BackColor = Color.DodgerBlue;

            // Panel mapa a la izquierda
            panelMapa.Dock = DockStyle.Left;
            panelMapa.Width = 940; // ancho fijo para el mapa

            // Panel formulario a la derecha (ocupa lo que sobra)
            panelForm.Dock = DockStyle.Fill;

            // Configuración del mapa
            gMapControl1.Parent = panelMapa;
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            // Centro en Corrientes Capital
            gMapControl1.Position = new PointLatLng(-27.4692, -58.8306);
            gMapControl1.MinZoom = 12;
            gMapControl1.MaxZoom = 19;
            gMapControl1.Zoom = 14;

            markerAlertas = new GMapOverlay("alertas");
            gMapControl1.Overlays.Add(markerAlertas);

            // ===== Datos iniciales =====
            CargarPatrullas();
       
            CargarAlertas();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Cargar calles desde archivo GeoJSON
            string ruta = Path.Combine(Application.StartupPath, @"..\..\Resources\calles.geojson");
            CargarCallesDesdeGeoJSON(ruta);


           
            gMapControl1.OnMarkerClick += GMapControl1_OnMarkerClick;
            dataGridViewAlertas.DataBindingComplete += dataGridViewAlertas_DataBindingComplete;
            dataGridViewAlertas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAlertas.MultiSelect = false;



        }

        private void CargarCallesDesdeGeoJSON(string rutaArchivo)
        {
            string json = File.ReadAllText(rutaArchivo);
            JObject geojson = JObject.Parse(json);

            foreach (var feature in geojson["features"])
            {
                string geometryType = feature["geometry"]["type"].ToString();
                var properties = feature["properties"];
                if (properties == null || properties["highway"] == null)
                    continue; // ignorar lo que no sea calle

                switch (geometryType)
                {
                    case "LineString":
                        ProcesarLinea(feature["geometry"]["coordinates"]);
                        break;
                    case "MultiLineString":
                        foreach (var line in feature["geometry"]["coordinates"])
                            ProcesarLinea(line);
                        break;
                }
            }
        }

        private void ProcesarLinea(JToken coordenadas)
        {
            Nodo nodoAnterior = null;

            foreach (var coord in coordenadas)
            {
                double lng = (double)coord[0];
                double lat = (double)coord[1];
                Nodo nodoActual = ObtenerONuevoNodo(lat, lng);

                // Conecta el nodo actual con el anterior (grafo bidireccional)
                if (nodoAnterior != null)
                {
                    double distancia = Distancia(nodoAnterior, nodoActual);
                    nodoAnterior.Vecinos.Add((nodoActual, distancia));
                    nodoActual.Vecinos.Add((nodoAnterior, distancia));
                }

                nodoAnterior = nodoActual;
            }
        }

        private Nodo ObtenerONuevoNodo(double lat, double lng)
        {
            var nodo = nodos.FirstOrDefault(n => Math.Abs(n.Lat - lat) < 1e-6 && Math.Abs(n.Lng - lng) < 1e-6);
            if (nodo == null)
            {
                nodo = new Nodo { Lat = lat, Lng = lng };
                nodos.Add(nodo);
            }
            return nodo;
        }

        // ===================== DISTANCIAS =====================
        private double Distancia(Nodo a, Nodo b)
        {
            double dx = a.Lng - b.Lng;
            double dy = a.Lat - b.Lat;
            return Math.Sqrt(dx * dx + dy * dy);
        }



        // ===================== UBICAR NODOS MÁS CERCANOS =====================
        private Nodo BuscarNodoMasCercano(PointLatLng punto)
        {
            Nodo masCercano = null;
            double minDist = double.MaxValue;

            foreach (var nodo in nodos)
            {
                double d = Math.Sqrt(Math.Pow(punto.Lat - nodo.Lat, 2) + Math.Pow(punto.Lng - nodo.Lng, 2));
                if (d < minDist)
                {
                    minDist = d;
                    masCercano = nodo;
                }
            }

            return masCercano;
        }

        // ===================== ALGORITMO DE DIJKSTRA =====================
        private List<Nodo> Dijkstra(Nodo nodoOrigen, Nodo nodoDestino)
        {
            // Distancias mínimas conocidas desde el origen
            var distanciaMinima = new Dictionary<Nodo, double>();

            // Nodo previo para reconstruir el camino
            var nodoAnterior = new Dictionary<Nodo, Nodo>();

            // Cola de prioridad (nodo con menor distancia estimada al inicio)
            var colaPrioridad = new SortedSet<(double distancia, Nodo nodo)>(
                Comparer<(double distancia, Nodo nodo)>.Create((primero, segundo) =>
                {
                    int comparacion = primero.distancia.CompareTo(segundo.distancia);
                    if (comparacion == 0) // si distancia es igual, usar hash para evitar duplicados
                        comparacion = primero.nodo.GetHashCode().CompareTo(segundo.nodo.GetHashCode());
                    return comparacion;
                })
            );

            // Inicializar todas las distancias como infinitas
            foreach (var nodo in nodos)
                distanciaMinima[nodo] = double.MaxValue;

            // La distancia al origen es 0
            distanciaMinima[nodoOrigen] = 0;
            colaPrioridad.Add((0, nodoOrigen));

            while (colaPrioridad.Any())
            {
                // Extraer el nodo con la menor distancia conocida
                var (distanciaActual, nodoActual) = colaPrioridad.Min;
                colaPrioridad.Remove(colaPrioridad.Min);

                // Si llegamos al destino, podemos terminar
                if (nodoActual == nodoDestino)
                    break;

                // Revisar conexiones del nodo actual
                foreach (var (nodoVecino, pesoConexion) in nodoActual.Vecinos)
                {
                    double nuevaDistancia = distanciaActual + pesoConexion;

                    // Si encontramos un camino más corto hacia el vecino
                    if (nuevaDistancia < distanciaMinima[nodoVecino])
                    {
                        // Actualizar la distancia en la cola de prioridad
                        colaPrioridad.Remove((distanciaMinima[nodoVecino], nodoVecino));
                        distanciaMinima[nodoVecino] = nuevaDistancia;
                        nodoAnterior[nodoVecino] = nodoActual;
                        colaPrioridad.Add((nuevaDistancia, nodoVecino));
                    }
                }
            }

            // Reconstruir el camino desde el destino hacia el origen
            var camino = new List<Nodo>();
            var nodoEnRecorrido = nodoDestino;

            while (nodoEnRecorrido != null)
            {
                camino.Add(nodoEnRecorrido);
                nodoAnterior.TryGetValue(nodoEnRecorrido, out nodoEnRecorrido);
            }

            camino.Reverse(); // invertir para que el camino empiece en el origen
            return camino;
        }

        // ===================== DIBUJAR RUTA =====================
        private void CalcularRuta(PointLatLng posPatrulla, PointLatLng posAlerta, string nombreRuta, Color color)
        {
            var nodoPatrulla = BuscarNodoMasCercano(posPatrulla);
            var nodoAlerta = BuscarNodoMasCercano(posAlerta);

            if (nodoPatrulla != null && nodoAlerta != null)
            {
                var camino = Dijkstra(nodoPatrulla, nodoAlerta);
                DibujarRuta(camino, nombreRuta, color, posPatrulla, posAlerta);
            }
        }


        private void DibujarRuta(List<Nodo> camino, string nombreRuta, Color color, PointLatLng patrulla, PointLatLng alerta)
        {
            if (overlayRutas == null)
                overlayRutas = new GMapOverlay("rutas");

            // Convertir nodos intermedios a puntos
            List<PointLatLng> ruta = camino.Select(n => new PointLatLng(n.Lat, n.Lng)).ToList();

            // Agregar patrulla al inicio si no está
            if (ruta.Count == 0 || ruta.First() != patrulla)
                ruta.Insert(0, patrulla);

            // Agregar alerta al final si no está
            if (ruta.Count == 0 || ruta.Last() != alerta)
                ruta.Add(alerta);

            // Crear la ruta visual
            GMapRoute gmapRoute = new GMapRoute(ruta, nombreRuta);
            gmapRoute.Stroke = new Pen(color, 3);

            // Evitar rutas duplicadas con el mismo nombre
            var rutaExistente = overlayRutas.Routes.FirstOrDefault(r => r.Name == nombreRuta);
            if (rutaExistente != null)
                overlayRutas.Routes.Remove(rutaExistente);

            overlayRutas.Routes.Add(gmapRoute);

            if (!gMapControl1.Overlays.Contains(overlayRutas))
                gMapControl1.Overlays.Add(overlayRutas);

            gMapControl1.Update();
            CargarAlertas();
        }

        private PointLatLng ObtenerCoordenadasPatrulla(int idPatrulla)
        {
            using (SqlConnection conexion = Database.GetConnection())
            {
                string sql = "SELECT latitud, longitud FROM Ubicacion WHERE id_patrulla = @id";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", idPatrulla);

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        double lat = Convert.ToDouble(lector["latitud"]);
                        double lng = Convert.ToDouble(lector["longitud"]);
                        return new PointLatLng(lat, lng);
                    }
                }
            }

            // Si no se encuentra, retornamos coordenada neutra
            return new PointLatLng(0, 0);
        }

        private PointLatLng ObtenerCoordenadasAlerta(int idAlerta)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT direccion FROM Alerta WHERE id_alerta = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idAlerta);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        string direccionCompleta = $"{dr["direccion"].ToString()}, Corrientes Capital, Corrientes, Argentina";

                        GeoCoderStatusCode status;
                        var point = GMapProviders.OpenStreetMap.GetPoint(direccionCompleta, out status);

                        if (status == GeoCoderStatusCode.G_GEO_SUCCESS && point != null)
                        {
                            return point.Value; // Devuelve la coordenada válida
                        }
                    }
                }
            }

            // Si no encontró dirección o falló el geocoder, devuelve (0,0)
            return new PointLatLng(0, 0);
        }

        private void EliminarRutaPorNombre(string nombreRuta)
        {
            if (string.IsNullOrEmpty(nombreRuta)) return;

            if (gMapControl1.InvokeRequired)
            {
                gMapControl1.Invoke(new Action(() => EliminarRutaPorNombre(nombreRuta)));
                return;
            }

            var overlay = gMapControl1.Overlays.FirstOrDefault(o => o.Id == "rutas");
            if (overlay == null) return;

            var rutasAEliminar = overlay.Routes
                .Where(r => string.Equals(r.Name, nombreRuta, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var r in rutasAEliminar)
                overlay.Routes.Remove(r);

            gMapControl1.Update();
        }



        private void GMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            try
            {
                // =================== 📍 Clic en una patrulla ===================
                if (item.Tag is int idPatrulla)
                {
                    string codigoPatrulla = ObtenerCodigoPatrullaPorId(idPatrulla);

                    if (idPatrulla <= 0 || string.IsNullOrEmpty(codigoPatrulla))
                    {
                        MessageBox.Show("No se pudo obtener la información de la patrulla seleccionada.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 🚫 Verificar si ya está ocupada
                    if (PatrullaOcupada(idPatrulla))
                    {
                        MessageBox.Show($"La patrulla {codigoPatrulla} ya está asignada a una alerta.",
                                        "Patrulla ocupada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // ✅ Guardamos selección para el siguiente clic (en alerta)
                    patrullaSeleccionada = codigoPatrulla;
                    idPatrullaSeleccionada = idPatrulla;

                    // 🔹 Guardamos posición actual (orden = 1)
                    origen = item.Position;

                    MessageBox.Show($"Patrulla {codigoPatrulla} seleccionada como origen.",
                                    "Seleccionar patrulla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // =================== 🚨 Clic en una alerta ===================
                if (item.Tag?.ToString() == "Alerta")
                {
                    if (string.IsNullOrEmpty(patrullaSeleccionada) || idPatrullaSeleccionada <= 0)
                    {
                        MessageBox.Show("Seleccioná primero una patrulla disponible.",
                                        "Asignar alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // 🧭 Obtenemos los datos base
                    string[] partes = item.ToolTipText.Split(new[] { ", " }, 2, StringSplitOptions.None);
                    string delito = partes[0];
                    string direccion = partes.Length > 1 ? partes[1] : "";

                    int idAlerta = ObtenerIdAlertaPorDireccion(direccion);
                    idPatrulla = idPatrullaSeleccionada;

                    if (idAlerta <= 0)
                    {
                        MessageBox.Show("No se pudo obtener la información de la alerta.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        patrullaSeleccionada = null;
                        idPatrullaSeleccionada = 0;
                        return;
                    }

                    // 🚫 Si la patrulla fue asignada mientras tanto
                    if (PatrullaOcupada(idPatrulla))
                    {
                        MessageBox.Show($"La patrulla {patrullaSeleccionada} ya fue asignada.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        patrullaSeleccionada = null;
                        idPatrullaSeleccionada = 0;
                        return;
                    }

                    // ✅ Asignar en base de datos
                    AsignarPatrullaAlerta(idPatrulla, idAlerta);

                    // 🔹 Borrar ruta anterior (por si existía)
                    EliminarRutaPorNombre($"Ruta_P{idPatrulla}_A{idAlerta}");

                    // 🔹 Obtener coordenadas actualizadas de la patrulla (orden = 1)
                    PointLatLng posPatrulla = ObtenerCoordenadasPrimeraUbicacion(idPatrulla);
                    PointLatLng posAlerta = item.Position;

                    if (posPatrulla.Lat == 0 && posPatrulla.Lng == 0)
                    {
                        MessageBox.Show("No se encontró una ubicación válida para la patrulla.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 🔹 Dibujar nueva ruta
                    string nombreRuta = $"Ruta_P{idPatrulla}_A{idAlerta}";
                    CalcularRuta(posPatrulla, posAlerta, nombreRuta, Color.Blue);

                    // 🔄 Actualizar mapa y alertas
                    CargarAlertas();
                    gMapControl1.Update();

                    // ✅ Reset selección
                    patrullaSeleccionada = null;
                    idPatrullaSeleccionada = 0;
                    origen = PointLatLng.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el clic en el mapa: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerCodigoPatrullaPorId(int idPatrulla)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "SELECT codigo_patrulla FROM Patrulla WHERE id_patrulla = @idPatrulla";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idPatrulla", idPatrulla);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            return result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el código de la patrulla: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;
        }

        private void dataGridViewAlertas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridViewAlertas.Columns[e.ColumnIndex].Name;

            // ✅ Guardar patrulla anterior (ya lo tenías)
            if (colName == "Patrulla")
            {
                valorAnteriorPatrulla = dataGridViewAlertas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            }

            // ✅ Guardar estado anterior (lo agregamos)
            if (colName == "Estado")
            {
                estadoAnterior = dataGridViewAlertas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            }
        }

        private void dataGridViewAlertas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = dataGridViewAlertas;
            if (grid.Columns[e.ColumnIndex].Name != "Patrulla") return;

            // 📌 Datos base
            string codigoNuevo = grid.Rows[e.RowIndex].Cells["Patrulla"].Value?.ToString() ?? "Sin Asignar";
            string direccionAlerta = grid.Rows[e.RowIndex].Cells["Direccion"].Value?.ToString();
            int idAlerta = ObtenerIdAlertaPorDireccion(direccionAlerta);

            if (idAlerta <= 0)
            {
                MessageBox.Show("No se encontró el ID de la alerta seleccionada.");
                return;
            }

            // 🔹 Caso: "Sin Asignar" → eliminar ruta y liberar
            if (codigoNuevo == "Sin Asignar")
            {
                if (!string.IsNullOrEmpty(valorAnteriorPatrulla) && valorAnteriorPatrulla != "Sin Asignar")
                {
                    int idPatrullaAnterior = ObtenerIdPatrullaPorCodigo(valorAnteriorPatrulla);
                    EliminarRutaPorNombre($"Ruta_P{idPatrullaAnterior}_A{idAlerta}");
                    LiberarPatrullaDeAlerta(idAlerta);
                }

                CargarAlertas();
                valorAnteriorPatrulla = null;
                return;
            }

            // 🔹 Caso: nueva patrulla asignada
            int idPatrullaNueva = ObtenerIdPatrullaPorCodigo(codigoNuevo);

            // 🚫 Verificar si ya está asignada a otra alerta en la BDD
            if (PatrullaOcupada(idPatrullaNueva))
            {
                MessageBox.Show($"La patrulla {codigoNuevo} ya está cumpliendo una alerta.",
                    "Patrulla ocupada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                grid.Rows[e.RowIndex].Cells["Patrulla"].Value = valorAnteriorPatrulla ?? "Sin Asignar";
                return;
            }

            // 🔹 Si tenía patrulla anterior distinta → liberar y borrar ruta vieja
            if (!string.IsNullOrEmpty(valorAnteriorPatrulla) &&
                valorAnteriorPatrulla != "Sin Asignar" &&
                valorAnteriorPatrulla != codigoNuevo)
            {
                int idPatrullaAnterior = ObtenerIdPatrullaPorCodigo(valorAnteriorPatrulla);
                EliminarRutaPorNombre($"Ruta_P{idPatrullaAnterior}_A{idAlerta}");
                LiberarPatrullaDeAlerta(idAlerta);
            }

            // 🔹 Asignar nueva patrulla
            AsignarPatrullaAlerta(idPatrullaNueva, idAlerta);

            // 🔹 Obtener coordenadas
            PointLatLng posPatrulla = ObtenerCoordenadasPatrulla(idPatrullaNueva);
            PointLatLng posAlerta = ObtenerCoordenadasAlerta(idAlerta);

            if (posPatrulla.Lat == 0 && posPatrulla.Lng == 0)
            {
                MessageBox.Show("No se encontraron coordenadas para la patrulla.");
                return;
            }

            if (posAlerta.Lat == 0 && posAlerta.Lng == 0)
            {
                MessageBox.Show("No se encontraron coordenadas para la alerta.");
                return;
            }

            // 🔹 Dibujar nueva ruta
            string nombreRuta = $"Ruta_P{idPatrullaNueva}_A{idAlerta}";
            CalcularRuta(posPatrulla, posAlerta, nombreRuta, Color.Blue);

            // 🔹 Refrescar grilla
            CargarAlertas();
            valorAnteriorPatrulla = null;

            // ------------------------------------------------------------------
            // ✅ Control de cambios en columna ESTADO
            // ------------------------------------------------------------------
            if (dataGridViewAlertas.Columns[e.ColumnIndex].Name == "Estado")
            {
                string nuevoEstado = dataGridViewAlertas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // ❌ No permitir En Espera → Atendida directo
                if (estadoAnterior == "En Espera" && nuevoEstado == "Atendida")
                {
                    MessageBox.Show("No se puede pasar de 'En Espera' directamente a 'Atendida'. Debe estar primero 'Asignada'.",
                        "Cambio inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dataGridViewAlertas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = estadoAnterior;
                    return;
                }

                if (nuevoEstado == "Atendida")
                {
                    idAlerta = Convert.ToInt32(
                        dataGridViewAlertas.Rows[e.RowIndex].Cells["IdAlerta"].Value
                    );

                    FormReporte frm = new FormReporte(idAlerta);
                    DialogResult result = frm.ShowDialog();

                    if (result == DialogResult.Cancel)
                    {
                        dataGridViewAlertas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Asignada";
                    }
                }
            }

        }
        
        private PointLatLng ObtenerCoordenadasPrimeraUbicacion(int idPatrulla)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            SELECT TOP 1 latitud, longitud
            FROM Ubicacion
            WHERE id_patrulla = @id AND orden = 1
        ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idPatrulla);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        double lat = Convert.ToDouble(reader["latitud"]);
                        double lng = Convert.ToDouble(reader["longitud"]);
                        return new PointLatLng(lat, lng);
                    }
                }
            }

            return new PointLatLng(0, 0);
        }

        private int ObtenerIdAlertaPorDireccion(string direccion)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id_alerta FROM Alerta WHERE direccion = @dir";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dir", direccion);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private int ObtenerIdPatrullaPorCodigo(string codigo)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id_patrulla FROM Patrulla WHERE codigo_patrulla = @cod";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cod", codigo);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private bool PatrullaOcupada(int idPatrulla)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Alerta WHERE id_patrulla = @id AND estado = 'Asignada'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idPatrulla);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void AsignarPatrullaAlerta(int idPatrulla, int idAlerta)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE Alerta SET id_patrulla = @patrulla, estado = 'Asignada' WHERE id_alerta = @alerta";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@patrulla", idPatrulla);
                    cmd.Parameters.AddWithValue("@alerta", idAlerta);

                    int filas = cmd.ExecuteNonQuery();

                    // Opcional: ver si realmente se modificó algo
                    if (filas == 0)
                    {
                        MessageBox.Show("⚠️ No se encontró la alerta o no se actualizó ninguna fila.");
                    }
                }
            }
        }

        private void LiberarPatrullaDeAlerta(int idAlerta)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            UPDATE Alerta 
            SET id_patrulla = NULL, estado = 'En Espera'
            WHERE id_alerta = @alerta AND estado = 'Asignada'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@alerta", idAlerta);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnJurisdicciones_Click(object sender, EventArgs e)
        {
            if (jurisdiccionesVisibles)
            {
                // Ocultar todas las jurisdicciones y comisarias
                polygonOverlay.Polygons.Clear();
                markerComisarias.Markers.Clear();
                jurisdiccionesVisibles = false;

            }
            else
            {
                // Volver a cargar las jurisdicciones y marcadores
                CargarJurisdicciones();
                CargarComisarias();

                jurisdiccionesVisibles = true;

            }
            gMapControl1.Refresh(); // refresca el mapa
        }

        private void CargarAlertas()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {

                    string query = @"
                        SELECT 
                            a.id_alerta,
                            COALESCE(p.codigo_patrulla, 'Sin Asignar') AS Patrulla,
                            a.estado AS Estado,
                            a.tipo_incidencia AS Incidente,
                            l.telefono AS Telefono,
                            l.nombre AS Nombre,
                            a.direccion AS Direccion
                        FROM Alerta AS a
                        LEFT JOIN Patrulla AS p ON a.id_patrulla = p.id_patrulla
                        LEFT JOIN Llamada AS l ON a.id_alerta = l.id_alerta
                     ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 🔹 Limpio columnas previas
                    dataGridViewAlertas.Columns.Clear();
                    dataGridViewAlertas.AutoGenerateColumns = false;

                    // 🔹 Columna oculta para id_alerta para despues leerla y generar reporte
                    DataGridViewTextBoxColumn colIdAlerta = new DataGridViewTextBoxColumn();
                    colIdAlerta.Name = "id_alerta";
                    colIdAlerta.DataPropertyName = "id_alerta";
                    colIdAlerta.HeaderText = "ID Alerta";
                    colIdAlerta.Visible = false; // oculta en la UI
                    dataGridViewAlertas.Columns.Add(colIdAlerta);

                    // 🔹 Columna Patrulla (ComboBox)
                    DataGridViewComboBoxColumn colPatrulla = new DataGridViewComboBoxColumn();
                    colPatrulla.HeaderText = "Patrulla";
                    colPatrulla.DataPropertyName = "Patrulla";
                    colPatrulla.Name = "Patrulla";
                    colPatrulla.DisplayMember = "codigo_patrulla";
                    colPatrulla.FlatStyle = FlatStyle.Popup;
                    colPatrulla.ValueMember = "codigo_patrulla";
                    colPatrulla.DataSource = ObtenerPatrullas();
                    dataGridViewAlertas.Columns.Add(colPatrulla);

                    // 🔹 Columna Estado (ComboBox)
                    DataGridViewComboBoxColumn colEstado = new DataGridViewComboBoxColumn();
                    colEstado.HeaderText = "Estado";
                    colEstado.DataPropertyName = "Estado";
                    colEstado.FlatStyle = FlatStyle.Popup;
                    colEstado.Name = "Estado";
                    colEstado.Items.Add("En Espera");
                    colEstado.Items.Add("Asignada");
                    colEstado.Items.Add("Atendida");
                    dataGridViewAlertas.Columns.Add(colEstado);

                    DataGridViewTextBoxColumn colIncidente = new DataGridViewTextBoxColumn();
                    colIncidente.DataPropertyName = "Incidente";
                    colIncidente.HeaderText = "Incidente";
                    colIncidente.Name = "Incidente";
                    dataGridViewAlertas.Columns.Add(colIncidente);

                    DataGridViewTextBoxColumn colTelefono = new DataGridViewTextBoxColumn();
                    colTelefono.DataPropertyName = "Telefono";
                    colTelefono.HeaderText = "Telefono";
                    colTelefono.Name = "Telefono";
                    dataGridViewAlertas.Columns.Add(colTelefono);

                    DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                    colNombre.DataPropertyName = "Nombre";
                    colNombre.HeaderText = "Nombre";
                    colNombre.Name = "Nombre";
                    dataGridViewAlertas.Columns.Add(colNombre);

                    DataGridViewTextBoxColumn colDireccion = new DataGridViewTextBoxColumn();
                    colDireccion.DataPropertyName = "Direccion";
                    colDireccion.HeaderText = "Direccion";
                    colDireccion.Name = "Direccion";
                    dataGridViewAlertas.Columns.Add(colDireccion);


                    dataGridViewAlertas.DataSource = dt;

                    markerAlertas.Markers.Clear();

                    foreach (DataGridViewRow row in dataGridViewAlertas.Rows)
                    {
                        string direccion = row.Cells["Direccion"].Value?.ToString();
                        string incidente = row.Cells["Incidente"].Value?.ToString();

                        if (!string.IsNullOrWhiteSpace(direccion))
                        {
                            string direccionCompleta = $"{direccion}, Corrientes Capital, Corrientes, Argentina";
                            GeoCoderStatusCode status;
                            var point = GMapProviders.OpenStreetMap.GetPoint(direccionCompleta, out status);

                            if (status == GeoCoderStatusCode.G_GEO_SUCCESS && point != null)
                            {
                                var marker = new GMarkerGoogle(point.Value, GMarkerGoogleType.red)
                                {
                                    Tag = "Alerta",
                                    ToolTipText = $"{incidente}" + ", " + $"{direccion}",
                                    ToolTipMode = MarkerTooltipMode.OnMouseOver
                                };

                                markerAlertas.Markers.Add(marker);
                            }
                        }
                    }

                    for (int i = 0; i < dataGridViewAlertas.Rows.Count; i++)
                    {
                        string tipoIncidente = dataGridViewAlertas.Rows[i].Cells["Incidente"].Value?.ToString() ?? "";
                        PintarFila(i, tipoIncidente);
                    }

                    dataGridViewAlertas.CellValueChanged -= dataGridViewAlertas_CellValueChanged;
                    dataGridViewAlertas.CellValueChanged += dataGridViewAlertas_CellValueChanged;
                    dataGridViewAlertas.CurrentCellDirtyStateChanged += (s, e) =>
                    {
                        if (dataGridViewAlertas.IsCurrentCellDirty)
                            dataGridViewAlertas.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    };

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las alertas: " + ex.Message);
            }
        }

        private DataTable ObtenerPatrullas()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
        SELECT DISTINCT 
            p.id_patrulla, 
            p.codigo_patrulla
        FROM Patrulla AS p
        INNER JOIN Ubicacion AS u ON p.id_patrulla = u.id_patrulla
        WHERE p.activo = 1 AND p.estado = 'En Servicio';
        ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Agregar la opción "Sin Asignar"
                DataRow filaSinAsignar = dt.NewRow();
                filaSinAsignar["id_patrulla"] = DBNull.Value;
                filaSinAsignar["codigo_patrulla"] = "Sin Asignar";
                dt.Rows.InsertAt(filaSinAsignar, 0);
                return dt;
            }

        }

        private void CargarJurisdicciones()
        {
            // ----------------- OVERLAY PARA POLÍGONOS -----------------
            polygonOverlay = new GMapOverlay("jurisdicciones");

            // Polígono de la Jurisdicción Comisaría 1ra
            List<PointLatLng> puntosComisaria1 = new List<PointLatLng>()
            {
                new PointLatLng(-27.473096, -58.856358),
                new PointLatLng(-27.475712, -58.836306),
                new PointLatLng(-27.460509, -58.834962),
                new PointLatLng(-27.461272, -58.841489),
                new PointLatLng(-27.462319, -58.844152),
                new PointLatLng(-27.464599, -58.848095),
                new PointLatLng(-27.465770, -58.850758),
                new PointLatLng(-27.466546, -58.852367),
                new PointLatLng(-27.469428, -58.854733),
                new PointLatLng(-27.473096, -58.856358)
            };
            AgregarPoligono(puntosComisaria1, "Jurisdicción Comisaría 1ra", Color.Red);

            // Polígono de la Jurisdicción Comisaría 4ta
            List<PointLatLng> puntosComisaria4 = new List<PointLatLng>()
            {
                new PointLatLng(-27.460508, -58.834946),
                new PointLatLng(-27.469912, -58.835807),
                new PointLatLng(-27.471151, -58.823015),
                new PointLatLng(-27.467552, -58.822545),
                new PointLatLng(-27.467000, -58.821589),
                new PointLatLng(-27.466437, -58.821923),
                new PointLatLng(-27.463166, -58.821711),
                new PointLatLng(-27.455825, -58.821413),
                new PointLatLng(-27.456849, -58.824476),
                new PointLatLng(-27.457636, -58.826632),
                new PointLatLng(-27.458904, -58.831493),
                new PointLatLng(-27.460508, -58.834946)
            };
            AgregarPoligono(puntosComisaria4, "Jurisdicción Comisaría 4ta", Color.Green);

            // Polígono de la Jurisdicción Comisaría 1ra Mujer y 3ra
            List<PointLatLng> puntosJurisdiccion = new List<PointLatLng>()
            {
                new PointLatLng(-27.469912, -58.835807),
                new PointLatLng(-27.485333, -58.837662),
                new PointLatLng(-27.485715, -58.834181),
                new PointLatLng(-27.483202, -58.825832),
                new PointLatLng(-27.484662, -58.824536),
                new PointLatLng(-27.471153, -58.823088),
                new PointLatLng(-27.469912, -58.835807)
            };
            AgregarPoligono(puntosJurisdiccion, "Jurisdicción Comisaría 1ra Mujer y 3ra", Color.Purple);

            // Polígono de la Jurisdicción Comisaría 2da
            List<PointLatLng> puntosComisaria2 = new List<PointLatLng>()
            {
                new PointLatLng(-27.4731117652088, -58.8563588261604),
                new PointLatLng(-27.4732093340713, -58.8563561439514),
                new PointLatLng(-27.4745038981179, -58.8567584753037),
                new PointLatLng(-27.4765266239913, -58.8566029071808),
                new PointLatLng(-27.4789062539459, -58.85646879673),
                new PointLatLng(-27.4874867726734, -58.8562488555908),
                new PointLatLng(-27.4888002040637, -58.8557982444763),
                new PointLatLng(-27.4889429674013, -58.8547146320343),
                new PointLatLng(-27.4892760811359, -58.8526627421379),
                new PointLatLng(-27.4887169253646, -58.8525125384331),
                new PointLatLng(-27.4885194356264, -58.8517883419991),
                new PointLatLng(-27.4879317231055, -58.8518339395523),
                new PointLatLng(-27.4871584123781, -58.849969804287),
                new PointLatLng(-27.4860543531903, -58.8472312688828),
                new PointLatLng(-27.4854832837501, -58.8457641005516),
                new PointLatLng(-27.4845148383889, -58.8455736637115),
                new PointLatLng(-27.4854166587891, -58.8377174735069),
                new PointLatLng(-27.4840365612486, -58.8375297188759),
                new PointLatLng(-27.4816356262131, -58.8372427225113),
                new PointLatLng(-27.4782589996872, -58.836829662323),
                new PointLatLng(-27.4757080194051, -58.8365185260773),
                new PointLatLng(-27.4731189043968, -58.8563641905785)
            };
            AgregarPoligono(puntosComisaria2, "Jurisdicción Comisaría 2da", Color.Orange);

            // Polígono de la Jurisdicción Comisaría 12va
            List<PointLatLng> puntosComisaria12 = new List<PointLatLng>()
            {
                new PointLatLng(-27.488819239186, -58.8557928800583),
                new PointLatLng(-27.4912795010552, -58.8543176651001),
                new PointLatLng(-27.4925833699713, -58.8539260625839),
                new PointLatLng(-27.492816541982, -58.8539582490921),
                new PointLatLng(-27.49306398929, -58.8540977239609),
                new PointLatLng(-27.4934018491393, -58.8538563251495),
                new PointLatLng(-27.4936302608444, -58.8537222146988),
                new PointLatLng(-27.4938681892, -58.8537275791168),
                new PointLatLng(-27.4938872234462, -58.8541781902313),
                new PointLatLng(-27.494034738743, -58.8542801141739),
                new PointLatLng(-27.4942917004007, -58.8539904356003),
                new PointLatLng(-27.4944534907664, -58.8538563251495),
                new PointLatLng(-27.4954194694725, -58.8537007570267),
                new PointLatLng(-27.4956478769915, -58.8538080453873),
                new PointLatLng(-27.4958382162287, -58.8537490367889),
                new PointLatLng(-27.4967137724809, -58.8529282808304),
                new PointLatLng(-27.497237199523, -58.8518285751343),
                new PointLatLng(-27.498931182706, -58.8493072986603),
                new PointLatLng(-27.5002539941423, -58.8479125499725),
                new PointLatLng(-27.5013055703081, -58.8465070724487),
                new PointLatLng(-27.5029804582061, -58.8448816537857),
                new PointLatLng(-27.5040557989312, -58.8442754745483),
                new PointLatLng(-27.5052786293763, -58.8435298204422),
                new PointLatLng(-27.5073007899844, -58.8419795036316),
                new PointLatLng(-27.5088804284166, -58.840434551239),
                new PointLatLng(-27.5088043017834, -58.8400268554688),
                new PointLatLng(-27.5081762550495, -58.8401556015015),
                new PointLatLng(-27.5078146507583, -58.8399624824524),
                new PointLatLng(-27.5080810961408, -58.8394260406494),
                new PointLatLng(-27.5087472067739, -58.8391041755676),
                new PointLatLng(-27.509032681525, -58.8383531570435),
                new PointLatLng(-27.5096036288051, -58.837730884552),
                new PointLatLng(-27.5097749124113, -58.8372159004211),
                new PointLatLng(-27.5101745731222, -58.8370871543884),
                new PointLatLng(-27.5109429643385, -58.836824297905),
                new PointLatLng(-27.5098962381377, -58.8350835442543),
                new PointLatLng(-27.5066727346683, -58.8352739810944),
                new PointLatLng(-27.5022191486851, -58.8361430168152),
                new PointLatLng(-27.4981793619266, -58.8368189334869),
                new PointLatLng(-27.4980080602712, -58.83809030056),
                new PointLatLng(-27.4979271677302, -58.8381707668304),
                new PointLatLng(-27.4959429026689, -58.8381707668304),
                new PointLatLng(-27.4939395676064, -58.8381332159042),
                new PointLatLng(-27.4888763445334, -58.8380795717239),
                new PointLatLng(-27.486387475663, -58.838084936142),
                new PointLatLng(-27.4854214177163, -58.8378864526749),
                new PointLatLng(-27.4845457716648, -58.8455522060394),
                new PointLatLng(-27.4854785248256, -58.8457399606705),
                new PointLatLng(-27.4879531377868, -58.8518124818802),
                new PointLatLng(-27.4885241944195, -58.851769566536),
                new PointLatLng(-27.4887383398932, -58.852499127388),
                new PointLatLng(-27.4892808398962, -58.8526386022568),
                new PointLatLng(-27.4888144804058, -58.8557982444763)

            };
            AgregarPoligono(puntosComisaria12, "Jurisdicción Comisaría 12", Color.Violet);

            // Polígono de jurisdicción Comisaría 7ma
            List<PointLatLng> puntosComisaria7 = new List<PointLatLng>()
            {
                new PointLatLng(-27.4854261766432, -58.8378810882568),
                new PointLatLng(-27.486377957892, -58.8380742073059),
                new PointLatLng(-27.4979509596602, -58.8381278514862),
                new PointLatLng(-27.4981603284225, -58.8367974758148),
                new PointLatLng(-27.5009391851827, -58.8363415002823),
                new PointLatLng(-27.5012698834989, -58.8340884447098),
                new PointLatLng(-27.501479245948, -58.8325756788254),
                new PointLatLng(-27.5016124763901, -58.8312909007072),
                new PointLatLng(-27.5016576795391, -58.831245303154),
                new PointLatLng(-27.5018694203586, -58.8295742869377),
                new PointLatLng(-27.502359515524, -58.8261544704437),
                new PointLatLng(-27.4993475369408, -58.825660943985),
                new PointLatLng(-27.4995164573527, -58.8244619965553),
                new PointLatLng(-27.5012151637022, -58.8219085335732),
                new PointLatLng(-27.4994474617229, -58.8181453943253),
                new PointLatLng(-27.4981627076107, -58.8152351975441),
                new PointLatLng(-27.4953909184993, -58.8171207904816),
                new PointLatLng(-27.4931472647012, -58.8186013698578),
                new PointLatLng(-27.4916268836987, -58.8196125626564),
                new PointLatLng(-27.490277795652, -58.8202965259552),
                new PointLatLng(-27.488619370237, -58.8214203715324),
                new PointLatLng(-27.4861519105902, -58.8233837485313),
                new PointLatLng(-27.4846790225999, -58.8245397806168),
                new PointLatLng(-27.4832084944233, -58.825835287571),
                new PointLatLng(-27.4857164707959, -58.8341662287712),
                new PointLatLng(-27.4853762079004, -58.8376638293266),
                new PointLatLng(-27.4854261766432, -58.8376799225807),
                new PointLatLng(-27.4854261766432, -58.8378810882568)
            };
            AgregarPoligono(puntosComisaria7, "Jurisdicción Comisaría 7ma", Color.Brown);

            List<PointLatLng> puntosComisaria6 = new List<PointLatLng>()
            {
                new PointLatLng(-27.4558073943475, -58.8213801383972),
                new PointLatLng(-27.4664459415415, -58.8218978047371),
                new PointLatLng(-27.4666815487513, -58.8217610120773),
                new PointLatLng(-27.4667220065044, -58.8209161162376),
                new PointLatLng(-27.4669052561410, -58.8182982802391),
                new PointLatLng(-27.4675287785966, -58.8145700097084),
                new PointLatLng(-27.4675573367926, -58.8137680292130),
                new PointLatLng(-27.4672455760864, -58.8097715377808),
                new PointLatLng(-27.4648276157833, -58.8093718886375),
                new PointLatLng(-27.4634972390203, -58.8091814517975),
                new PointLatLng(-27.4618812499432, -58.8089990615845),
                new PointLatLng(-27.4619026696882, -58.8089373707771),
                new PointLatLng(-27.4617384515366, -58.8088059425354),
                new PointLatLng(-27.4614219144092, -58.8087791204453),
                new PointLatLng(-27.4613148151754, -58.8088542222977),
                new PointLatLng(-27.4609030771520, -58.8088944554329),
                new PointLatLng(-27.4606603175968, -58.8093852996826),
                new PointLatLng(-27.4606626975951, -58.8094952702522),
                new PointLatLng(-27.4610744365162, -58.8097071647644),
                new PointLatLng(-27.4611672560606, -58.8100048899651),
                new PointLatLng(-27.4610434966507, -58.8113996386528),
                new PointLatLng(-27.4607531374899, -58.8120245933533),
                new PointLatLng(-27.4604865775870, -58.8130196928978),
                new PointLatLng(-27.4604865775870, -58.8130196928978),
                new PointLatLng(-27.4588110434404, -58.8151949644089),
                new PointLatLng(-27.4581089299420, -58.8158386945724),
                new PointLatLng(-27.4575186751351, -58.8159433007240),
                new PointLatLng(-27.4571259635332, -58.8158145546913),
                new PointLatLng(-27.4568403542170, -58.8159701228142),
                new PointLatLng(-27.4568117932447, -58.8164046406746),
                new PointLatLng(-27.4568760554220, -58.8166514039040),
                new PointLatLng(-27.4568141733260, -58.8169786334038),
                new PointLatLng(-27.4566689882722, -58.8172468543053),
                new PointLatLng(-27.4564357397527, -58.8180327415466),
                new PointLatLng(-27.4562667532722, -58.8183572888374),
                new PointLatLng(-27.4563238754918, -58.8187274336815),
                new PointLatLng(-27.4561596490308, -58.8198029994965),
                new PointLatLng(-27.4559359198353, -58.8203206658363),
                new PointLatLng(-27.4557217106057, -58.8204976916313),
                new PointLatLng(-27.4556788687099, -58.8207283616066),
                new PointLatLng(-27.4558002540382, -58.8207337260246),
                new PointLatLng(-27.4558288152725, -58.8214096426964),
                new PointLatLng(-27.4558073943475, -58.8213801383972)
            };
            AgregarPoligono(puntosComisaria6, "Jurisdicción Comisaría 6ta", Color.Blue);

            // Polígono irregular de la Comisaría Contravencional
            List<PointLatLng> puntosComisariaContravencional = new List<PointLatLng>()
            {
                new PointLatLng(-27.4666886883559, -58.8217529654503),
                new PointLatLng(-27.4670123499434, -58.8215678930283),
                new PointLatLng(-27.4675549569432, -58.8225200772285),
                new PointLatLng(-27.4711722686734, -58.8229975104332),
                new PointLatLng(-27.4711722686734, -58.8230699300766),
                new PointLatLng(-27.4745538717928, -58.8234373927116),
                new PointLatLng(-27.4755009876305, -58.8139021396637),
                new PointLatLng(-27.4769716186999, -58.8071671128273),
                new PointLatLng(-27.4769835169295, -58.8070785999298),
                new PointLatLng(-27.4811858912341, -58.8078618049622),
                new PointLatLng(-27.4866492140417, -58.8081943988800),
                new PointLatLng(-27.4864993094100, -58.8072636723518),
                new PointLatLng(-27.4874344254455, -58.8003408908844),
                new PointLatLng(-27.4831180729562, -58.7995576858521),
                new PointLatLng(-27.4796534471478, -58.7990748882294),
                new PointLatLng(-27.4749988744692, -58.7981897592545),
                new PointLatLng(-27.4739803630190, -58.8013386726379),
                new PointLatLng(-27.4739565659100, -58.8014137744904),
                new PointLatLng(-27.4711246732373, -58.8004428148270),
                new PointLatLng(-27.4690970885681, -58.8004052639008),
                new PointLatLng(-27.4690399729668, -58.8010060787201),
                new PointLatLng(-27.4672550955104, -58.8071376085281),
                new PointLatLng(-27.4671408623690, -58.8078832626343),
                new PointLatLng(-27.4672455760864, -58.8097554445267),
                new PointLatLng(-27.4675644763404, -58.8137626647949),
                new PointLatLng(-27.4675406778458, -58.8145405054092),
                new PointLatLng(-27.4669219151838, -58.8182634115219),
                new PointLatLng(-27.4666934480920, -58.8217556476593),
                new PointLatLng(-27.4666886883559, -58.8217529654503)
            };
            AgregarPoligono(puntosComisariaContravencional, "Jurisdicción Comisaría Contravencional", Color.Aqua);

            // Polígono irregular de la Comisaría 19na
            List<PointLatLng> puntosComisaria19 = new List<PointLatLng>()
            {
                new PointLatLng(-27.4745657702835, -58.8234427571297),
                new PointLatLng(-27.4755081266637, -58.8139235973358),
                new PointLatLng(-27.4770025540942, -58.8071000576019),
                new PointLatLng(-27.4812620369682, -58.8078832626343),
                new PointLatLng(-27.4866539729156, -58.8082158565521),
                new PointLatLng(-27.4872440716799, -58.8113218545914),
                new PointLatLng(-27.486820533371, -58.8162410259247),
                new PointLatLng(-27.4912795010552, -58.8170295953751),
                new PointLatLng(-27.4940299801881, -58.8174962997437),
                new PointLatLng(-27.4941870123903, -58.8179039955139),
                new PointLatLng(-27.4916126077212, -58.8196098804474),
                new PointLatLng(-27.4902516227046, -58.8202965259552),
                new PointLatLng(-27.4866301785442, -58.8229733705521),
                new PointLatLng(-27.4846647457218, -58.8245290517807),
                new PointLatLng(-27.4745610108873, -58.8234454393387),
                new PointLatLng(-27.4745657702835, -58.8234427571297)
            };
            AgregarPoligono(puntosComisaria19, "Jurisdicción Comisaría 19", Color.BlueViolet);

            // Polígono irregular de la Comisaría 9na
            List<PointLatLng> puntosComisaria9 = new List<PointLatLng>()
                {
                    new PointLatLng(-27.4681213596460, -58.7960225343704),
                    new PointLatLng(-27.4632045063789, -58.7959635257721),
                    new PointLatLng(-27.4630474300069, -58.7959098815918),
                    new PointLatLng(-27.4606864975746, -58.7958401441574),
                    new PointLatLng(-27.4600534163703, -58.7956470251083),
                    new PointLatLng(-27.4591156879064, -58.7950998544693),
                    new PointLatLng(-27.4566023458884, -58.7938338518143),
                    new PointLatLng(-27.4539604189419, -58.7911838293076),
                    new PointLatLng(-27.4551266827847, -58.7841725349426),
                    new PointLatLng(-27.4513136683029, -58.7713193893433),
                    new PointLatLng(-27.4494047313849, -58.7660998106003),
                    new PointLatLng(-27.4277376487585, -58.7618350982666),
                    new PointLatLng(-27.3926499547873, -58.7380599975586),
                    new PointLatLng(-27.4539032954981, -58.7222671508789),
                    new PointLatLng(-27.4852786498133, -58.7284469604492),
                    new PointLatLng(-27.4838319246238, -58.7415790557861),
                    new PointLatLng(-27.4842887872630, -58.7470722198486),
                    new PointLatLng(-27.4781971295957, -58.7826061248779),
                    new PointLatLng(-27.4708866957483, -58.7799453735352),
                    new PointLatLng(-27.4609482970101, -58.7673497200012),
                    new PointLatLng(-27.4681213596460, -58.7960225343704)
                };
            AgregarPoligono(puntosComisaria9, "Jurisdicción Comisaría 9na", Color.Orange);

            // Polígono irregular de la Comisaría 11ra
            List<PointLatLng> puntosComisaria11 = new List<PointLatLng>()
                {
                    new PointLatLng(-27.4672384365180, -58.8097608089447),
                    new PointLatLng(-27.4619121895736, -58.8089722394943),
                    new PointLatLng(-27.4619121895736, -58.8089346885681),
                    new PointLatLng(-27.4617408315116, -58.8087952136993),
                    new PointLatLng(-27.4614219144092, -58.8087657094002),
                    new PointLatLng(-27.4613029152541, -58.8088461756706),
                    new PointLatLng(-27.4609125971237, -58.8088837265968),
                    new PointLatLng(-27.4611577361109, -58.8084492087364),
                    new PointLatLng(-27.4612410356427, -58.8071644306183),
                    new PointLatLng(-27.4597916148098, -58.8051769137383),
                    new PointLatLng(-27.4600605564042, -58.8041925430298),
                    new PointLatLng(-27.4609125971237, -58.8039055466652),
                    new PointLatLng(-27.4612029558645, -58.8028299808502),
                    new PointLatLng(-27.4607793174456, -58.8020038604736),
                    new PointLatLng(-27.4599391757658, -58.8020440936089),
                    new PointLatLng(-27.4591775687108, -58.8010892271996),
                    new PointLatLng(-27.4590728473293, -58.8005045056343),
                    new PointLatLng(-27.4587586825880, -58.8001665472984),
                    new PointLatLng(-27.4587182219123, -58.7996354699135),
                    new PointLatLng(-27.4592608697387, -58.7990292906761),
                    new PointLatLng(-27.4567594314429, -58.7943220138550),
                    new PointLatLng(-27.4572735280568, -58.7940537929535),
                    new PointLatLng(-27.4579589864800, -58.7946224212646),
                    new PointLatLng(-27.4591014077159, -58.7952232360840),
                    new PointLatLng(-27.4600724564596, -58.7957060337067),
                    new PointLatLng(-27.4607102975490, -58.7959045171738),
                    new PointLatLng(-27.4681975144092, -58.7960493564606),
                    new PointLatLng(-27.4691161270953, -58.8000458478928),
                    new PointLatLng(-27.4690209344264, -58.8009953498840),
                    new PointLatLng(-27.4672408163742, -58.8071376085281),
                    new PointLatLng(-27.4671551415181, -58.8076794147491),
                    new PointLatLng(-27.4671265832180, -58.8081622123718),
                    new PointLatLng(-27.4672384365180, -58.8097608089447)
                };
            AgregarPoligono(puntosComisaria11, "Jurisdicción Comisaría 11ra", Color.Purple);

            // Polígono irregular de la Comisaría 15ta
            List<PointLatLng> puntosComisaria15 = new List<PointLatLng>()
                {
                    new PointLatLng(-27.5009558390785, -58.8363415002823),
                    new PointLatLng(-27.5066679766598, -58.8352605700493),
                    new PointLatLng(-27.5098986170722, -58.8350728154182),
                    new PointLatLng(-27.5109501010738, -58.8368135690689),
                    new PointLatLng(-27.5112688747814, -58.8367277383804),
                    new PointLatLng(-27.5119206927707, -58.8364407420158),
                    new PointLatLng(-27.5127342703898, -58.835751414299),
                    new PointLatLng(-27.5132576212335, -58.8355824351311),
                    new PointLatLng(-27.5134836128735, -58.8354778289795),
                    new PointLatLng(-27.5137310137155, -58.8349172472954),
                    new PointLatLng(-27.5139474889958, -58.8347375392914),
                    new PointLatLng(-27.5139950659234, -58.8347536325455),
                    new PointLatLng(-27.5140711889647, -58.836110830307),
                    new PointLatLng(-27.5143685440901, -58.836113512516),
                    new PointLatLng(-27.5152534681874, -58.8356360793114),
                    new PointLatLng(-27.5157244732716, -58.8355153799057),
                    new PointLatLng(-27.5155817446712, -58.8342922925949),
                    new PointLatLng(-27.5160693999579, -58.833948969841),
                    new PointLatLng(-27.5162216431167, -58.8340884447098),
                    new PointLatLng(-27.5170423252650, -58.8338255882263),
                    new PointLatLng(-27.5176370186474, -58.833409845829),
                    new PointLatLng(-27.5182103000239, -58.8333347439766),
                    new PointLatLng(-27.5186860499347, -58.833415210247),
                    new PointLatLng(-27.5199848367125, -58.8327527046204),
                    new PointLatLng(-27.5222017779719, -58.8309073448181),
                    new PointLatLng(-27.5330099157296, -58.8306713104248),
                    new PointLatLng(-27.5379188949334, -58.8320016860962),
                    new PointLatLng(-27.5477361954454, -58.8326454162598),
                    new PointLatLng(-27.5520737929418, -58.831787109375),
                    new PointLatLng(-27.5580091750524, -58.8254356384277),
                    new PointLatLng(-27.5594168788654, -58.8244485855103),
                    new PointLatLng(-27.5570960602256, -58.8243198394775),
                    new PointLatLng(-27.5559546560132, -58.821873664856),
                    new PointLatLng(-27.5569438736829, -58.8156938552856),
                    new PointLatLng(-27.5576667578823, -58.81432056427),
                    new PointLatLng(-27.5583135449738, -58.8138055801392),
                    new PointLatLng(-27.5561448908726, -58.8082265853882),
                    new PointLatLng(-27.5551556660047, -58.806939125061),
                    new PointLatLng(-27.5544327652732, -58.8032054901123),
                    new PointLatLng(-27.5551556660047, -58.8007164001465),
                    new PointLatLng(-27.5533293812970, -58.7986135482788),
                    new PointLatLng(-27.5539761939380, -58.796854019165),
                    new PointLatLng(-27.5515791632846, -58.7963819503784),
                    new PointLatLng(-27.5491820803115, -58.7938928604126),
                    new PointLatLng(-27.5459858883000, -58.7928628921509),
                    new PointLatLng(-27.5445019103956, -58.7946224212646),
                    new PointLatLng(-27.5406206426408, -58.7938499450684),
                    new PointLatLng(-27.5377286285066, -58.7948369979858),
                    new PointLatLng(-27.5338090668215, -58.7947940826416),
                    new PointLatLng(-27.5318302058789, -58.7965106964111),
                    new PointLatLng(-27.5303840926595, -58.797025680542),
                    new PointLatLng(-27.5290521294418, -58.7971115112305),
                    new PointLatLng(-27.5276440364913, -58.7979698181152),
                    new PointLatLng(-27.5244234317765, -58.7972563505173),
                    new PointLatLng(-27.5224039645967, -58.7994021177292),
                    new PointLatLng(-27.5222398366591, -58.7996220588684),
                    new PointLatLng(-27.5210980703136, -58.800273835659),
                    new PointLatLng(-27.5188073658326, -58.8017624616623),
                    new PointLatLng(-27.5154080912910, -58.8054236769676),
                    new PointLatLng(-27.5131339203497, -58.8079690933228),
                    new PointLatLng(-27.5120110905811, -58.8090848922729),
                    new PointLatLng(-27.5106979361433, -58.8098037242889),
                    new PointLatLng(-27.5087852701169, -58.8103938102722),
                    new PointLatLng(-27.5068345068349, -58.8107585906982),
                    new PointLatLng(-27.5041985424853, -58.8119065761566),
                    new PointLatLng(-27.5031136868309, -58.8124537467957),
                    new PointLatLng(-27.5001826198302, -58.8138055801392),
                    new PointLatLng(-27.4981936370525, -58.8152325153351),
                    new PointLatLng(-27.5012389549215, -58.8219058513641),
                    new PointLatLng(-27.4995640405206, -58.8244807720184),
                    new PointLatLng(-27.4993737077259, -58.8256394863129),
                    new PointLatLng(-27.5023904437865, -58.8261330127716),
                    new PointLatLng(-27.5016862288869, -58.8312613964081),
                    new PointLatLng(-27.5016291301840, -58.8313364982605),
                    new PointLatLng(-27.5009629764616, -58.8363361358643),
                    new PointLatLng(-27.5009558390785, -58.8363415002823)
                };
            AgregarPoligono(puntosComisaria15, "Jurisdicción Comisaría 15ta", Color.DarkBlue);

            // Polígono irregular de la Comisaría 8va
            List<PointLatLng> puntosComisaria8 = new List<PointLatLng>()
                {
                    new PointLatLng(-27.4868348099697, -58.8162329792976),
                    new PointLatLng(-27.4921979212789, -58.8171797990799),
                    new PointLatLng(-27.4925881285887, -58.8140657544136),
                    new PointLatLng(-27.4927118525689, -58.8135507702827),
                    new PointLatLng(-27.4928236798929, -58.8124591112137),
                    new PointLatLng(-27.4928236798929, -58.8111448287964),
                    new PointLatLng(-27.49306398929,   -58.8089293241501),
                    new PointLatLng(-27.4929783345155, -58.8086664676666),
                    new PointLatLng(-27.4934898828735, -58.8058742880821),
                    new PointLatLng(-27.4956859448653, -58.8012689352036),
                    new PointLatLng(-27.4961213452352, -58.8002952933311),
                    new PointLatLng(-27.4965971906644, -58.8004374504089),
                    new PointLatLng(-27.4968422502581, -58.8005071878433),
                    new PointLatLng(-27.4972681292249, -58.8003838062286),
                    new PointLatLng(-27.4998542973988, -58.7985759973526),
                    new PointLatLng(-27.4984791391821, -58.7974923849106),
                    new PointLatLng(-27.4960618644119, -58.7966072559357),
                    new PointLatLng(-27.4960618644119, -58.7966126203537),
                    new PointLatLng(-27.4885955762903, -58.7954163551331),
                    new PointLatLng(-27.4868205333710, -58.7951722741127),
                    new PointLatLng(-27.4864088906446, -58.7954190373421),
                    new PointLatLng(-27.4848408270903, -58.7953600287437),
                    new PointLatLng(-27.4834416862855, -58.7954941391945),
                    new PointLatLng(-27.4833560240261, -58.7955504655838),
                    new PointLatLng(-27.4812977302629, -58.7992975115776),
                    new PointLatLng(-27.4874487019647, -58.8003328442574),
                    new PointLatLng(-27.4865064477304, -58.8072583079338),
                    new PointLatLng(-27.4872535893760, -58.8113191723824),
                    new PointLatLng(-27.4868276716706, -58.8162329792976),
                    new PointLatLng(-27.4868348099697, -58.8162329792976)
                };
            AgregarPoligono(puntosComisaria8, "Jurisdicción Comisaría 8va", Color.DarkGreen);

            // Polígono irregular de la Comisaría 21ra
            List<PointLatLng> puntosComisaria21 = new List<PointLatLng>()
            {
                new PointLatLng(-27.4922074385468, -58.8171824812889),
                new PointLatLng(-27.4940299801881, -58.8174855709076),
                new PointLatLng(-27.4941917709384, -58.8179013133049),
                new PointLatLng(-27.5001921364079, -58.8137868046761),
                new PointLatLng(-27.5041533403798, -58.8119146227837),
                new PointLatLng(-27.5068130958265, -58.8107559084892),
                new PointLatLng(-27.5087947859505, -58.8103777170181),
                new PointLatLng(-27.5106979361433, -58.8097983598709),
                new PointLatLng(-27.5119991961366, -58.8090822100639),
                new PointLatLng(-27.5138309254363, -58.8071832060814),
                new PointLatLng(-27.5125606125142, -58.8033047318459),
                new PointLatLng(-27.5113545153216, -58.7997481226921),
                new PointLatLng(-27.5097083021517, -58.7980958819389),
                new PointLatLng(-27.5094918185294, -58.7980717420578),
                new PointLatLng(-27.5083998781612, -58.7979805469513),
                new PointLatLng(-27.5013460153446, -58.7975084781647),
                new PointLatLng(-27.4998542973988, -58.7985679507256),
                new PointLatLng(-27.4972657500173, -58.8003972172737),
                new PointLatLng(-27.4968446294748, -58.8005152344704),
                new PointLatLng(-27.4961261036996, -58.8003033399582),
                new PointLatLng(-27.4934946414517, -58.8058796525002),
                new PointLatLng(-27.4929926103159, -58.8086664676666),
                new PointLatLng(-27.4930711271848, -58.8089212775230),
                new PointLatLng(-27.4928308178033, -58.8111555576324),
                new PointLatLng(-27.4928284384999, -58.8124671578407),
                new PointLatLng(-27.4927189904866, -58.8135427236557),
                new PointLatLng(-27.4926000251313, -58.8140791654587),
                new PointLatLng(-27.4922074385468, -58.8171797990799),
                new PointLatLng(-27.4940347387430, -58.8174882531166),
                new PointLatLng(-27.4922074385468, -58.8171824812889)
            };
            AgregarPoligono(puntosComisaria21, "Jurisdicción Comisaría 21ra", Color.Yellow);

            // Polígono irregular de la Comisaría 14ta
            List<PointLatLng> puntosComisaria14 = new List<PointLatLng>()
            {
                new PointLatLng(-27.5138285465869, -58.8071537017822),
                new PointLatLng(-27.5188145020578, -58.8017249107361),
                new PointLatLng(-27.5222398366591, -58.7996113300323),
                new PointLatLng(-27.5244377034974, -58.7972295284271),
                new PointLatLng(-27.5276440364913, -58.7979590892792),
                new PointLatLng(-27.5290045590284, -58.7970256805420),
                new PointLatLng(-27.5297371411124, -58.7967896461487),
                new PointLatLng(-27.5318206920383, -58.7964248657227),
                new PointLatLng(-27.5328291545578, -58.7952125072479),
                new PointLatLng(-27.5333619234742, -58.7945902347565),
                new PointLatLng(-27.5357498381382, -58.7947618961334),
                new PointLatLng(-27.5384421259086, -58.7944185733795),
                new PointLatLng(-27.5405921033995, -58.7937104701996),
                new PointLatLng(-27.5437979651488, -58.7936782836914),
                new PointLatLng(-27.5444258084242, -58.7940752506256),
                new PointLatLng(-27.5451012115779, -58.7927663326263),
                new PointLatLng(-27.5464520054275, -58.7915110588074),
                new PointLatLng(-27.5467088446322, -58.7915539741516),
                new PointLatLng(-27.5474603336707, -58.7931096553802),
                new PointLatLng(-27.5484781650569, -58.7931096553802),
                new PointLatLng(-27.5490964692378, -58.7910819053650),
                new PointLatLng(-27.5495720854699, -58.7907063961029),
                new PointLatLng(-27.5488206108794, -58.7891507148743),
                new PointLatLng(-27.5490013457442, -58.7871122360229),
                new PointLatLng(-27.5498003805298, -58.7858998775482),
                new PointLatLng(-27.5493913515443, -58.7843549251556),
                new PointLatLng(-27.5489062221682, -58.7827026844025),
                new PointLatLng(-27.5482974293312, -58.7807822227478),
                new PointLatLng(-27.5494864747001, -58.7793338298798),
                new PointLatLng(-27.5491154939266, -58.7789046764374),
                new PointLatLng(-27.5494008638636, -58.7782824039459),
                new PointLatLng(-27.5487064623905, -58.7764263153076),
                new PointLatLng(-27.5478122951234, -58.7755680084229),
                new PointLatLng(-27.5474603336707, -58.7730789184570),
                new PointLatLng(-27.5478883947487, -58.7712550163269),
                new PointLatLng(-27.5483735286204, -58.7701177597046),
                new PointLatLng(-27.5467564073819, -58.7691414356232),
                new PointLatLng(-27.5461285774266, -58.7654507160187),
                new PointLatLng(-27.5456624589267, -58.7646031379700),
                new PointLatLng(-27.5460715017982, -58.7637877464294),
                new PointLatLng(-27.5458717368652, -58.7624895572662),
                new PointLatLng(-27.5464520054275, -58.7611484527588),
                new PointLatLng(-27.5463283418926, -58.7596893310547),
                new PointLatLng(-27.5467183571838, -58.7596893310547),
                new PointLatLng(-27.5481071808776, -58.7584447860718),
                new PointLatLng(-27.5491820803115, -58.7547969818115),
                new PointLatLng(-27.5499240401558, -58.7536811828613),
                new PointLatLng(-27.5506755071966, -58.7541747093201),
                new PointLatLng(-27.5519976962165, -58.7537240982056),
                new PointLatLng(-27.5530249975595, -58.7529516220093),
                new PointLatLng(-27.5526254926236, -58.7520074844360),
                new PointLatLng(-27.5507040438183, -58.7521523237228),
                new PointLatLng(-27.5397073832426, -58.7636321783066),
                new PointLatLng(-27.5352551349788, -58.7676286697388),
                new PointLatLng(-27.5268258120323, -58.7769198417664),
                new PointLatLng(-27.5164262195296, -58.7888181209564),
                new PointLatLng(-27.5161122183676, -58.7884426116943),
                new PointLatLng(-27.5133432602254, -58.7919080257416),
                new PointLatLng(-27.5111642029196, -58.7945795059204),
                new PointLatLng(-27.5092800923768, -58.7972939014435),
                new PointLatLng(-27.5088804284166, -58.7980073690414),
                new PointLatLng(-27.5097130600287, -58.7980851531029),
                new PointLatLng(-27.5097201968439, -58.7980958819389),
                new PointLatLng(-27.5113640309330, -58.7997293472290),
                new PointLatLng(-27.5138333042857, -58.8071724772453),
                new PointLatLng(-27.5138285465869, -58.8071537017822)
            };
            AgregarPoligono(puntosComisaria14, "Jurisdicción Comisaría 14ta", Color.DarkMagenta);

            // Polígono de la jurisdicción Comisaría 13ra
            List<PointLatLng> puntosComisaria13 = new List<PointLatLng>
            {
                new PointLatLng(-27.5023238290566, -58.7975406646729),
                new PointLatLng(-27.5023904437865, -58.7948021292686),
                new PointLatLng(-27.5024832285218, -58.7911596894264),
                new PointLatLng(-27.5025355685944, -58.7883111834526),
                new PointLatLng(-27.5032207454303, -58.7823271751404),
                new PointLatLng(-27.5036822857554, -58.7793043255806),
                new PointLatLng(-27.5036846648242, -58.7792399525642),
                new PointLatLng(-27.5031255822359, -58.7794947624207),
                new PointLatLng(-27.5027425495466, -58.7794491648674),
                new PointLatLng(-27.5014721085983, -58.7798407673836),
                new PointLatLng(-27.4975346001426, -58.7816298007965),
                new PointLatLng(-27.4963426136156, -58.7818631529808),
                new PointLatLng(-27.4962617198507, -58.7819302082062),
                new PointLatLng(-27.4961784467953, -58.7821260094643),
                new PointLatLng(-27.4955193978204, -58.7820374965668),
                new PointLatLng(-27.4961665506394, -58.7775635719299),
                new PointLatLng(-27.4963235797939, -58.7762841582298),
                new PointLatLng(-27.4966994971631, -58.7735778093338),
                new PointLatLng(-27.4969945200220, -58.7715178728104),
                new PointLatLng(-27.4971943737676, -58.7713971734047),
                new PointLatLng(-27.4973085757450, -58.7711262702942),
                new PointLatLng(-27.4976012177713, -58.7692755460739),
                new PointLatLng(-27.5009344269263, -58.7699621915817),
                new PointLatLng(-27.5008416408853, -58.7706649303436),
                new PointLatLng(-27.5012627461357, -58.7707534432411),
                new PointLatLng(-27.5016243719574, -58.7706112861633),
                new PointLatLng(-27.5017909097652, -58.7704235315323),
                new PointLatLng(-27.5018717994666, -58.7704208493233),
                new PointLatLng(-27.5046434253742, -58.7709116935730),
                new PointLatLng(-27.5047885472109, -58.7709867954254),
                new PointLatLng(-27.5050597579993, -58.7708124518394),
                new PointLatLng(-27.5057996366634, -58.7717592716217),
                new PointLatLng(-27.5061802796971, -58.7720891833305),
                new PointLatLng(-27.5063468106103, -58.7731030583382),
                new PointLatLng(-27.5078431985087, -58.7753668427467),
                new PointLatLng(-27.5096060077459, -58.7779524922371),
                new PointLatLng(-27.5103268244397, -58.7790066003799),
                new PointLatLng(-27.5102649723674, -58.7806373834610),
                new PointLatLng(-27.5101912256203, -58.7825149297714),
                new PointLatLng(-27.5109857847437, -58.7836843729019),
                new PointLatLng(-27.5111380349386, -58.7853500247002),
                new PointLatLng(-27.5137000886407, -58.7874823808670),
                new PointLatLng(-27.5148038705438, -58.7879222631454),
                new PointLatLng(-27.5153985760293, -58.7878417968750),
                new PointLatLng(-27.5160598847535, -58.7883085012436),
                new PointLatLng(-27.5161027031669, -58.7884372472763),
                new PointLatLng(-27.5100508687716, -58.7961405515671),
                new PointLatLng(-27.5088566388494, -58.7980020046234),
                new PointLatLng(-27.5026759350297, -58.7975996732712),
                new PointLatLng(-27.5023238290566, -58.7975406646729)
            };
            AgregarPoligono(puntosComisaria13, "Jurisdicción Comisaría 13ra", Color.Black);

            // Polígono de la jurisdicción Riachuelo
            List<PointLatLng> puntosRiachuelo = new List<PointLatLng>
            {
                new PointLatLng(-27.5610908815265, -58.8226890563965),
                new PointLatLng(-27.570221355756, -58.8198566436768),
                new PointLatLng(-27.5766122357459, -58.8231182098389),
                new PointLatLng(-27.5794271481169, -58.8286972045898),
                new PointLatLng(-27.5874910917509, -58.8258647918701),
                new PointLatLng(-27.5886321679601, -58.8214015960693),
                new PointLatLng(-27.5979124800513, -58.8176250457764),
                new PointLatLng(-27.6077244144558, -58.8185691833496),
                new PointLatLng(-27.6122117505519, -58.822774887085),
                new PointLatLng(-27.6192085858021, -58.822774887085),
                new PointLatLng(-27.6297030004805, -58.8111019134521),
                new PointLatLng(-27.6408807268791, -58.81178855896),
                new PointLatLng(-27.6454427360491, -58.8089561462402),
                new PointLatLng(-27.6505367547775, -58.8032054901123),
                new PointLatLng(-27.6449865436932, -58.7653541564941),
                new PointLatLng(-27.6394360509825, -58.7283611297607),
                new PointLatLng(-27.6271175134432, -58.710765838623),
                new PointLatLng(-27.6246840580954, -58.6877632141113),
                new PointLatLng(-27.6147975895629, -58.6626148223877),
                new PointLatLng(-27.5788946026678, -58.6681938171387),
                new PointLatLng(-27.5606343378777, -58.656005859375),
                new PointLatLng(-27.5352170807974, -58.6584091186523),
                new PointLatLng(-27.5343037764902, -58.6592674255371),
                new PointLatLng(-27.5313735406018, -58.6587309837341),
                new PointLatLng(-27.5319633995606, -58.6619925498962),
                new PointLatLng(-27.534665293686, -58.6632370948792),
                new PointLatLng(-27.5357878921352, -58.6661338806152),
                new PointLatLng(-27.5354454056883, -58.6686015129089),
                new PointLatLng(-27.5414768164325, -58.6680436134338),
                new PointLatLng(-27.5432652468286, -58.6702752113342),
                new PointLatLng(-27.5436267345419, -58.6740732192993),
                new PointLatLng(-27.5454722059094, -58.6772918701172),
                new PointLatLng(-27.5442736043233, -58.6807894706726),
                new PointLatLng(-27.5438169907554, -58.6811542510986),
                new PointLatLng(-27.5440072466393, -58.6814546585083),
                new PointLatLng(-27.5471654461798, -58.6816263198853),
                new PointLatLng(-27.5561448908726, -58.6845016479492),
                new PointLatLng(-27.5561448908726, -58.684287071228),
                new PointLatLng(-27.5550415241004, -58.6832356452942),
                new PointLatLng(-27.5553649258546, -58.6827635765076),
                new PointLatLng(-27.5567536402078, -58.6834931373596),
                new PointLatLng(-27.5571341068284, -58.6849737167358),
                new PointLatLng(-27.5599114732175, -58.6866474151611),
                new PointLatLng(-27.5614142654623, -58.6896944046021),
                new PointLatLng(-27.5606343378777, -58.6896729469299),
                new PointLatLng(-27.5604631335199, -58.6901235580444),
                new PointLatLng(-27.5623083219742, -58.6911106109619),
                new PointLatLng(-27.5629170371348, -58.6908745765686),
                new PointLatLng(-27.5629550817203, -58.6910676956177),
                new PointLatLng(-27.5584086604012, -58.6992216110229),
                new PointLatLng(-27.5590554431222, -58.6999297142029),
                new PointLatLng(-27.562003963128, -58.6991357803345),
                new PointLatLng(-27.5634877045322, -58.700122833252),
                new PointLatLng(-27.563430637926, -58.7009167671204),
                new PointLatLng(-27.559626130594, -58.7053799629211),
                new PointLatLng(-27.5601777923303, -58.7085342407227),
                new PointLatLng(-27.5597022220328, -58.7098217010498),
                new PointLatLng(-27.5560307499965, -58.7108516693115),
                new PointLatLng(-27.5561639143404, -58.711838722229),
                new PointLatLng(-27.5614523105686, -58.7139630317688),
                new PointLatLng(-27.5636969485013, -58.7184691429138),
                new PointLatLng(-27.5637730371184, -58.7178039550781),
                new PointLatLng(-27.5636589041729, -58.7172031402588),
                new PointLatLng(-27.5641725014929, -58.7178897857666),
                new PointLatLng(-27.5642866339043, -58.7192416191101),
                new PointLatLng(-27.5607484739679, -58.7232112884521),
                new PointLatLng(-27.5609006552369, -58.7247776985168),
                new PointLatLng(-27.5635067267277, -58.7282752990723),
                new PointLatLng(-27.5632974823961, -58.7294340133667),
                new PointLatLng(-27.5610147910502, -58.7308931350708),
                new PointLatLng(-27.5593027413909, -58.7314295768738),
                new PointLatLng(-27.559359810143, -58.7320733070374),
                new PointLatLng(-27.5603870426085, -58.7333178520203),
                new PointLatLng(-27.5606914059376, -58.7351417541504),
                new PointLatLng(-27.5619278732846, -58.7365579605103),
                new PointLatLng(-27.5644388102683, -58.7363219261169),
                new PointLatLng(-27.5657323008436, -58.7373518943787),
                new PointLatLng(-27.5655611044368, -58.73939037323),
                new PointLatLng(-27.5610338136742, -58.7419438362122),
                new PointLatLng(-27.5572482465575, -58.7400341033936),
                new PointLatLng(-27.5560878204494, -58.7402701377869),
                new PointLatLng(-27.5556312559958, -58.7416648864746),
                new PointLatLng(-27.5567916869291, -58.7444543838501),
                new PointLatLng(-27.5562400081787, -58.7465143203735),
                new PointLatLng(-27.556449265962, -58.7474584579468),
                new PointLatLng(-27.5562400081787, -58.7475228309631),
                new PointLatLng(-27.5558405149394, -58.7467932701111),
                new PointLatLng(-27.5549654294315, -58.7488317489624),
                new PointLatLng(-27.5556883266564, -58.7497758865356),
                new PointLatLng(-27.5568677803324, -58.7499690055847),
                new PointLatLng(-27.5569628970122, -58.750741481781),
                new PointLatLng(-27.5561258674015, -58.7519001960754),
                new PointLatLng(-27.5564302425437, -58.7542176246643),
                new PointLatLng(-27.5555932088724, -58.7549257278442),
                new PointLatLng(-27.5543947177344, -58.7555694580078),
                new PointLatLng(-27.5546800739537, -58.755784034729),
                new PointLatLng(-27.5552507841677, -58.7556123733521),
                new PointLatLng(-27.5542425274476, -58.7566423416138),
                new PointLatLng(-27.553843026941, -58.7567067146301),
                new PointLatLng(-27.5522830586646, -58.7612342834473),
                new PointLatLng(-27.5517884299499, -58.7629294395447),
                new PointLatLng(-27.552834757295, -58.7628436088562),
                new PointLatLng(-27.5545278840624, -58.7665128707886),
                new PointLatLng(-27.555498091006, -58.7662553787231),
                new PointLatLng(-27.5540713131227, -58.768572807312),
                new PointLatLng(-27.5546800739537, -58.7690019607544),
                new PointLatLng(-27.554565931555, -58.7694096565247),
                new PointLatLng(-27.5549844531037, -58.7701392173767),
                new PointLatLng(-27.5544327652732, -58.7736582756042),
                new PointLatLng(-27.5553459022484, -58.7744092941284),
                new PointLatLng(-27.5577048042873, -58.779194355011),
                new PointLatLng(-27.5579330824403, -58.7798166275024),
                new PointLatLng(-27.5571150835286, -58.7812542915344),
                new PointLatLng(-27.5576667578823, -58.7833786010742),
                new PointLatLng(-27.5584847526838, -58.7831425666809),
                new PointLatLng(-27.5585037757462, -58.7833142280579),
                new PointLatLng(-27.5578189434231, -58.7835288047791),
                new PointLatLng(-27.5583706142401, -58.7865972518921),
                new PointLatLng(-27.5592646955396, -58.7876486778259),
                new PointLatLng(-27.559207626738, -58.7915539741516),
                new PointLatLng(-27.5585418218611, -58.7924766540527),
                new PointLatLng(-27.5586369370908, -58.7934637069702),
                new PointLatLng(-27.559359810143, -58.7938499450684),
                new PointLatLng(-27.5601587695579, -58.7936997413635),
                new PointLatLng(-27.5626126799764, -58.7956094741821),
                new PointLatLng(-27.5626126799764, -58.7967681884766),
                new PointLatLng(-27.5619849406721, -58.7982058525085),
                new PointLatLng(-27.5623653891639, -58.798828125),
                new PointLatLng(-27.562289299571, -58.7992787361145),
                new PointLatLng(-27.563430637926, -58.8001155853271),
                new PointLatLng(-27.5625746352723, -58.800265789032),
                new PointLatLng(-27.5630501931262, -58.8037204742432),
                new PointLatLng(-27.562441478704, -58.8055014610291),
                new PointLatLng(-27.5629360594292, -58.8071966171265),
                new PointLatLng(-27.5637730371184, -58.807647228241),
                new PointLatLng(-27.5639822805435, -58.8082480430603),
                new PointLatLng(-27.5635828154767, -58.8088917732239),
                new PointLatLng(-27.5634686823335, -58.8102221488953),
                new PointLatLng(-27.5652187108222, -58.8111233711243),
                new PointLatLng(-27.5653708858939, -58.8125824928284),
                new PointLatLng(-27.5646860964098, -58.8139128684998),
                new PointLatLng(-27.5646860964098, -58.815586566925),
                new PointLatLng(-27.5643627221127, -58.8170027732849),
                new PointLatLng(-27.562593657626, -58.8187408447266),
                new PointLatLng(-27.5612430623208, -58.8192129135132),
                new PointLatLng(-27.5608816325898, -58.8199210166931),
                new PointLatLng(-27.5609006552369, -58.8204574584961),
                new PointLatLng(-27.5615664458083, -58.8208222389221),
                new PointLatLng(-27.561205017142, -58.8212084770203),
                new PointLatLng(-27.5610528362949, -58.8224530220032),
                new PointLatLng(-27.5610908815265, -58.8226890563965)
            };
            AgregarPoligono(puntosRiachuelo, "Jurisdicción Comisaria Riachuelo", Color.DarkOliveGreen);

            // Polígono de la jurisdicción Comisaria 18 y 2da de la mujer y menor
            List<PointLatLng> puntosComisaria18yMujer = new List<PointLatLng>
            {
                new PointLatLng(-27.4825755425945, -58.7953519821167),
                new PointLatLng(-27.4838319246238, -58.7906312942505),
                new PointLatLng(-27.4844030026267, -58.7823271751404),
                new PointLatLng(-27.4861733256177, -58.7697100639343),
                new PointLatLng(-27.4870870295756, -58.7672853469849),
                new PointLatLng(-27.4975940801701, -58.7691307067871),
                new PointLatLng(-27.4971658232547, -58.7713837623596),
                new PointLatLng(-27.4969469357434, -58.771448135376),
                new PointLatLng(-27.4954527789319, -58.7820214033127),
                new PointLatLng(-27.4961713091019, -58.7821233272552),
                new PointLatLng(-27.4963093044255, -58.7818872928619),
                new PointLatLng(-27.4976321473709, -58.7816351652145),
                new PointLatLng(-27.5019431726832, -58.7796342372894),
                new PointLatLng(-27.5027996476718, -58.7794840335846),
                new PointLatLng(-27.5032469152943, -58.7795162200928),
                new PointLatLng(-27.5037036973729, -58.7792694568634),
                new PointLatLng(-27.5027425495466, -58.7856316566467),
                new PointLatLng(-27.5024665748571, -58.7904167175293),
                new PointLatLng(-27.5023428618407, -58.7975406646729),
                new PointLatLng(-27.5013626691789, -58.7974226474762),
                new PointLatLng(-27.4999447051226, -58.7984418869019),
                new PointLatLng(-27.4961189660028, -58.7966179847717),
                new PointLatLng(-27.4868966752095, -58.7951803207397),
                new PointLatLng(-27.4863636812341, -58.7954914569855),
                new PointLatLng(-27.484850344994, -58.7953734397888),
                new PointLatLng(-27.4833750600895, -58.7955451011658),
                new PointLatLng(-27.4825755425945, -58.7953519821167)
            };
            AgregarPoligono(puntosComisaria18yMujer, "Jurisdicción Comisaria 18 y 2da de la Mujer y el Menor", Color.DarkOrange);

            // Polígono de la jurisdicción Comisaria 20
            List<PointLatLng> puntosComisaria20 = new List<PointLatLng>
            {
                new PointLatLng(-27.5165118560545, -58.78910779953),
                new PointLatLng(-27.5148942659848, -58.7879490852356),
                new PointLatLng(-27.5143233461629, -58.7879705429077),
                new PointLatLng(-27.511011952761, -58.7853741645813),
                new PointLatLng(-27.5108597023916, -58.7837433815002),
                new PointLatLng(-27.5100794159418, -58.782434463501),
                new PointLatLng(-27.5101936045484, -58.7790870666504),
                new PointLatLng(-27.5046172558423, -58.7708473205566),
                new PointLatLng(-27.5009820094811, -58.770546913147),
                new PointLatLng(-27.5175204589978, -58.6467790603638),
                new PointLatLng(-27.5217450726983, -58.6484098434448),
                new PointLatLng(-27.5226584813487, -58.6507701873779),
                new PointLatLng(-27.530878817744, -58.6508560180664),
                new PointLatLng(-27.5331240805271, -58.6573791503906),
                new PointLatLng(-27.5308027063374, -58.6581087112427),
                new PointLatLng(-27.5315638180312, -58.6627864837646),
                new PointLatLng(-27.5339612854183, -58.6636018753052),
                new PointLatLng(-27.535102918174, -58.6664772033691),
                new PointLatLng(-27.5347984839321, -58.6694812774658),
                new PointLatLng(-27.5418763619188, -58.6693954467773),
                new PointLatLng(-27.5445019103956, -58.6786651611328),
                new PointLatLng(-27.5428657063932, -58.6805105209351),
                new PointLatLng(-27.5430559639246, -58.6821413040161),
                new PointLatLng(-27.5460239387519, -58.6822700500488),
                new PointLatLng(-27.5493723269033, -58.6845874786377),
                new PointLatLng(-27.5562970785228, -58.6855316162109),
                new PointLatLng(-27.5567536402078, -58.6896944046021),
                new PointLatLng(-27.5551937132798, -58.6896085739136),
                new PointLatLng(-27.5554600438363, -58.6918830871582),
                new PointLatLng(-27.5614332880171, -58.6924409866333),
                new PointLatLng(-27.5578569897753, -58.6971187591553),
                new PointLatLng(-27.5581613601186, -58.6944150924683),
                new PointLatLng(-27.5561829378049, -58.694372177124),
                new PointLatLng(-27.5563731722688, -58.7002515792847),
                new PointLatLng(-27.5625746352723, -58.7005090713501),
                new PointLatLng(-27.5551556660047, -58.7117099761963),
                new PointLatLng(-27.5633735712901, -58.7193489074707),
                new PointLatLng(-27.5595310162214, -58.7234687805176),
                new PointLatLng(-27.5625746352723, -58.7286186218262),
                new PointLatLng(-27.5583135449738, -58.731107711792),
                new PointLatLng(-27.5608245646288, -58.7372446060181),
                new PointLatLng(-27.5642105456432, -58.7391328811646),
                new PointLatLng(-27.5593407872289, -58.7404632568359),
                new PointLatLng(-27.5574765256597, -58.7368583679199),
                new PointLatLng(-27.5538620508076, -58.7424802780151),
                new PointLatLng(-27.5500191628502, -58.7433815002441),
                new PointLatLng(-27.5491820803115, -58.7481880187988),
                new PointLatLng(-27.5535576685465, -58.7484884262085),
                new PointLatLng(-27.553976193938, -58.7500762939453),
                new PointLatLng(-27.5502474569808, -58.7514495849609),
                new PointLatLng(-27.5505898972869, -58.7526082992554),
                new PointLatLng(-27.5469751957656, -58.753981590271),
                new PointLatLng(-27.5165118560545, -58.78910779953)
            };
            AgregarPoligono(puntosComisaria20, "Jurisdicción Comisaria 20", Color.Crimson);

            // ---------------- Polígono de la Jurisdiccion de la Comisaría 16ta ----------------
            List<PointLatLng> puntosComisaria16 = new List<PointLatLng>()
            {
                new PointLatLng(-27.4612148557966, -58.768036365509),
                new PointLatLng(-27.4691732426571, -58.8002443313599),
                new PointLatLng(-27.4708486193024, -58.8002014160156),
                new PointLatLng(-27.4738946934024, -58.8012313842773),
                new PointLatLng(-27.474922724406,  -58.7980556488037),
                new PointLatLng(-27.4813952918761, -58.7991285324097),
                new PointLatLng(-27.4836034925935, -58.7911462783813),
                new PointLatLng(-27.4840603561803, -58.7833786010742),
                new PointLatLng(-27.4834131322064, -58.7828207015991),
                new PointLatLng(-27.4804053944255, -58.7836360931396),
                new PointLatLng(-27.4780829077971, -58.7834644317627),
                new PointLatLng(-27.4716482219041, -58.7809753417969),
                new PointLatLng(-27.467916693459,  -58.777027130127),
                new PointLatLng(-27.4612148557966, -58.768036365509) 
            };
            AgregarPoligono(puntosComisaria16, "Jurisdicción Comisaría 16ta", Color.Olive);

            // ---------------- Polígono de la Jurisdiccion de la Comisaría 10ma ----------------
            List<PointLatLng> puntosComisaria10 = new List<PointLatLng>()
                {
                    new PointLatLng(-27.4840413202353, -58.7821125984192),
                    new PointLatLng(-27.4804625041356, -58.7835288047791),
                    new PointLatLng(-27.4781971295957, -58.7828636169434),
                    new PointLatLng(-27.4794345248237, -58.7780785560608),
                    new PointLatLng(-27.4831085549027, -58.7576079368591),
                    new PointLatLng(-27.484555289594,  -58.7454199790955),
                    new PointLatLng(-27.4840222842871, -58.7417936325073),
                    new PointLatLng(-27.4841555358557, -58.7381887435913),
                    new PointLatLng(-27.4853928641505, -58.7308716773987),
                    new PointLatLng(-27.4861542900379, -58.7281680107117),
                    new PointLatLng(-27.489295116176,  -58.7216019630432),
                    new PointLatLng(-27.4979937851212, -58.633861541748),
                    new PointLatLng(-27.5072056303184, -58.6282825469971),
                    new PointLatLng(-27.514285284736,  -58.6439895629883),
                    new PointLatLng(-27.4982983212527, -58.7653541564941),
                    new PointLatLng(-27.4976892481473, -58.7690448760986),
                    new PointLatLng(-27.4869918524337, -58.7668132781982),
                    new PointLatLng(-27.4857355064513, -58.7709760665894),
                    new PointLatLng(-27.4840413202353, -58.7821125984192) // cerramos polígono
                };
            AgregarPoligono(puntosComisaria10, "Jurisdicción Comisaría 10ma", Color.Purple);

            // ---------------- Polígono de la Jurisdiccion de la Comisaría 17ma ----------------
            List<PointLatLng> puntosComisaria17 = new List<PointLatLng>()
            {
                new PointLatLng(-27.4539223366493, -58.7911033630371),
                new PointLatLng(-27.4551028816051, -58.7842798233032),
                new PointLatLng(-27.4513517514963, -58.7715125083923),
                new PointLatLng(-27.4501902081819, -58.766233921051),
                new PointLatLng(-27.4298516977404, -58.7622213363647),
                new PointLatLng(-27.4276614660575, -58.7743234634399),
                new PointLatLng(-27.4305182813668, -58.7756323814392),
                new PointLatLng(-27.4320799758153, -58.7793016433716),
                new PointLatLng(-27.4391454148103, -58.7845158576965),
                new PointLatLng(-27.4389359339076, -58.7861680984497),
                new PointLatLng(-27.4430302612957, -58.7880778312683),
                new PointLatLng(-27.4488191904972, -58.7879061698914),
                new PointLatLng(-27.4508566689564, -58.7908887863159),
                new PointLatLng(-27.4517897072752, -58.7900519371033),
                new PointLatLng(-27.4539223366493, -58.7911033630371) 
            };
            AgregarPoligono(puntosComisaria17, "Jurisdicción Comisaría 17ma", Color.Blue);
            // ----------------- AGREGAMOS OVERLAYS AL MAPA -----------------
            gMapControl1.Overlays.Add(polygonOverlay);
        }

        // Función auxiliar para crear y agregar un polígono al overlay
        private void AgregarPoligono(List<PointLatLng> puntos, string nombre, Color color)
        {
            var poligono = new GMapPolygon(puntos, nombre)
            {
                Fill = new SolidBrush(Color.FromArgb(50, color)), 
                Stroke = new Pen(color, 2)
            };

            polygonOverlay.Polygons.Add(poligono);
        }

        private void CargarComisarias()
        {
            markerComisarias = new GMapOverlay("markers");

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT nombre, direccion, telefono, latitud, longitud FROM Comisaria WHERE latitud IS NOT NULL AND longitud IS NOT NULL";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Obtenemos los datos de la comisaría
                    string nombre = reader["nombre"].ToString();
                    string direccion = reader["direccion"].ToString();
                    string telefono = reader["telefono"].ToString();

                    double lat = Convert.ToDouble(reader["latitud"]);
                    double lng = Convert.ToDouble(reader["longitud"]);

                    // Creamos el punto y el marcador
                    PointLatLng punto = new PointLatLng(lat, lng);
                    GMarkerGoogle marker = new GMarkerGoogle(punto, GMarkerGoogleType.blue_dot);

                    // Tooltip con información
                    marker.ToolTipText = $"{nombre}\nDirección: {direccion}\nTel: {telefono}";

                    // Agregamos al overlay
                    markerComisarias.Markers.Add(marker);
                }
            }

            // Finalmente agregamos la capa al mapa
            gMapControl1.Overlays.Add(markerComisarias);
        }


        private void CargarBomberos()
        {
            markerBomberos = new GMapOverlay("bomberos");
            // ---------------- Bomberos de la Policia - Cuartel 2 ----------------
            PointLatLng BomberosCuartel2 = new PointLatLng(-27.489398, -58.785644);
            GMarkerGoogle markerBomberosCuartel2 = new GMarkerGoogle(BomberosCuartel2, GMarkerGoogleType.orange_dot);
            markerBomberosCuartel2.ToolTipText = "Bomberos de la Policia - Cuartel 2";
            markerBomberos.Markers.Add(markerBomberosCuartel2);

            // ---------------- Cuartel de Bomberos del Aeropuerto de Corrientes ----------------
            PointLatLng BomberosCuartelAeropuerto = new PointLatLng(-27.447765, -58.758134);
            GMarkerGoogle markerBomberosCuartelAeropuerto = new GMarkerGoogle(BomberosCuartelAeropuerto, GMarkerGoogleType.orange_dot);
            markerBomberosCuartelAeropuerto.ToolTipText = "Cuartel de Bomberos del Aeropuerto de Corrientes";
            markerBomberos.Markers.Add(markerBomberosCuartelAeropuerto);

            // ---------------- Cuartel 4 bomberos corrientes capital ----------------
            PointLatLng BomberosCuartel4 = new PointLatLng(-27.470302, -58.800513);
            GMarkerGoogle markerBomberosCuartel4 = new GMarkerGoogle(BomberosCuartel4, GMarkerGoogleType.orange_dot);
            markerBomberosCuartel4.ToolTipText = "Cuartel 4 bomberos corrientes capital";
            markerBomberos.Markers.Add(markerBomberosCuartel4);

            // ---------------- Bomberos Policía de la Provincia de Corrientes ----------------
            PointLatLng BomberosPolicia = new PointLatLng(-27.476125, -58.831831);
            GMarkerGoogle markerBomberosPolicia = new GMarkerGoogle(BomberosPolicia, GMarkerGoogleType.orange_dot);
            markerBomberosPolicia.ToolTipText = "Bomberos Policía de la Provincia de Corrientes";
            markerBomberos.Markers.Add(markerBomberosPolicia);

            // ---------------- Asociación Bomberos Voluntarios ----------------
            PointLatLng BomberosVoluntarios = new PointLatLng(-27.487804, -58.832587);
            GMarkerGoogle markerBomberosVoluntarios = new GMarkerGoogle(BomberosVoluntarios, GMarkerGoogleType.orange_dot);
            markerBomberosVoluntarios.ToolTipText = "Asociación Bomberos Voluntarios";
            markerBomberos.Markers.Add(markerBomberosVoluntarios);

            // ---------------- Asociación de Bomberos Voluntarios Riachuelo ----------------
            PointLatLng BomberosVoluntariosRiachuelo = new PointLatLng(-27.579827, -58.743576);
            GMarkerGoogle markerBomberosVoluntariosRiachuelo = new GMarkerGoogle(BomberosVoluntariosRiachuelo, GMarkerGoogleType.orange_dot);
            markerBomberosVoluntariosRiachuelo.ToolTipText = "Asociación de Bomberos Voluntarios Riachuelo";
            markerBomberos.Markers.Add(markerBomberosVoluntariosRiachuelo);

            gMapControl1.Overlays.Add(markerBomberos);
        }


        private void CargarHospitales()
        {
            markerHospitales = new GMapOverlay("hospital");
            // ---------------- Hospital Juan Pablo II ----------------
            PointLatLng HospitalJuanPablo = new PointLatLng(-27.47577689779967, -58.81889708220148);
            GMarkerGoogle markerHospitalJuanPablo = new GMarkerGoogle(HospitalJuanPablo, GMarkerGoogleType.lightblue_dot);
            markerHospitalJuanPablo.ToolTipText = "Hospital Juan Pablo II";
            markerHospitales.Markers.Add(markerHospitalJuanPablo);

            // ---------------- Hospital de Campaña  ----------------
            PointLatLng HospitalCampaña = new PointLatLng(-27.477312177606823, -58.81788135673643);
            GMarkerGoogle markerHospitalCampaña = new GMarkerGoogle(HospitalCampaña, GMarkerGoogleType.lightblue_dot);
            markerHospitalCampaña.ToolTipText = "Hospital de Campaña ";
            markerHospitales.Markers.Add(markerHospitalCampaña);

            // ---------------- Hospital Angela Iglesia de Llano  ----------------
            PointLatLng HospitalLlano = new PointLatLng(-27.47577689779967, -58.81889708220148);
            GMarkerGoogle markerHospitalLlano = new GMarkerGoogle(HospitalLlano, GMarkerGoogleType.lightblue_dot);
            markerHospitalLlano.ToolTipText = "Hospital Angela Iglesia de Llano";
            markerHospitales.Markers.Add(markerHospitalLlano);

            // ---------------- Hospital Jose Ramon Vidal  ----------------
            PointLatLng HospitaVidal = new PointLatLng(-27.47954697199342, -58.8390440707281);
            GMarkerGoogle markerHospitaVidal = new GMarkerGoogle(HospitaVidal, GMarkerGoogleType.lightblue_dot);
            markerHospitaVidal.ToolTipText = "Hospital Jose Ramon Vidal";
            markerHospitales.Markers.Add(markerHospitaVidal);

            // ---------------- Hospital Escuela Jose de San Martin  ----------------
            PointLatLng HospitalEscuela = new PointLatLng(-27.47541576011016, -58.835972128451665);
            GMarkerGoogle markerHospitalEscuela = new GMarkerGoogle(HospitalEscuela, GMarkerGoogleType.lightblue_dot);
            markerHospitalEscuela.ToolTipText = "Hospital Escuela Jose de San Martin";
            markerHospitales.Markers.Add(markerHospitalEscuela);

            // ---------------- Hospital Riachuelo  ----------------
            PointLatLng HospitalRiachuelo = new PointLatLng(-27.581693913423443, -58.740014895754996);
            GMarkerGoogle markerHospitalRiachuelo = new GMarkerGoogle(HospitalRiachuelo, GMarkerGoogleType.lightblue_dot);
            markerHospitalRiachuelo.ToolTipText = "Hospital Riachuelo";
            markerHospitales.Markers.Add(markerHospitalRiachuelo);

            // ---------------- Clinica del Niño  ----------------
            PointLatLng HospitalNiño = new PointLatLng(-27.473016697490362, -58.82891050978708);
            GMarkerGoogle markerHospitalNiño = new GMarkerGoogle(HospitalNiño, GMarkerGoogleType.lightblue_dot);
            markerHospitalNiño.ToolTipText = "Clinica del Niño";
            markerHospitales.Markers.Add(markerHospitalNiño);

            gMapControl1.Overlays.Add(markerHospitales);
        }

        private void CargarPatrullas()
        {
            // Limpiar overlay anterior si existe
            if (markerPatrullas != null)
                gMapControl1.Overlays.Remove(markerPatrullas);

            markerPatrullas = new GMapOverlay("Patrullas");

            string ruta = Path.Combine(Application.StartupPath, @"..\..\Resources\iconoPatrulla.png");
            Bitmap icono = new Bitmap(ruta);

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
        SELECT 
            p.id_patrulla,
            p.codigo_patrulla,
            u.latitud,
            u.longitud,
            u.orden
        FROM Patrulla p
        INNER JOIN Ubicacion u ON p.id_patrulla = u.id_patrulla
        WHERE p.activo = 1 AND p.estado = 'En Servicio'
          AND u.orden = 1;"; 

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        double lat = Convert.ToDouble(reader["latitud"]);
                        double lng = Convert.ToDouble(reader["longitud"]);
                        string codigo = reader["codigo_patrulla"].ToString();
                        int idPatrulla = Convert.ToInt32(reader["id_patrulla"]);

                        PointLatLng punto = new PointLatLng(lat, lng);

                        var marker = new GMarkerGoogle(punto, icono)
                        {
                            Tag = idPatrulla, // 👈 Guardamos el id para actualizar luego
                            ToolTipText = $"Patrulla {codigo}",
                            ToolTipMode = MarkerTooltipMode.OnMouseOver
                        };

                        marker.Offset = new System.Drawing.Point(-icono.Width / 2, -(int)(icono.Height * 0.5));
                        marker.ToolTip.Offset = new System.Drawing.Point(0, -icono.Height + 5);

                        markerPatrullas.Markers.Add(marker);
                    }
                }
            }

            gMapControl1.Overlays.Add(markerPatrullas);
            gMapControl1.Refresh();
        }

        private void ActualizarUbicacionesYAlertas()
        {
            ordenActual++;
            if (ordenActual > 5) ordenActual = 1; // 🔁 vuelve al 1 después del último

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
        SELECT 
            p.id_patrulla,
            p.codigo_patrulla,
            u.latitud AS latPatrulla,
            u.longitud AS lngPatrulla,
            a.id_alerta,
            a.direccion
        FROM Patrulla p
        INNER JOIN Ubicacion u ON p.id_patrulla = u.id_patrulla
        LEFT JOIN Alerta a ON a.id_patrulla = p.id_patrulla AND a.estado = 'Asignada'
        WHERE p.activo = 1 AND p.estado = 'En Servicio'
          AND u.orden = @orden;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@orden", ordenActual);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idPatrulla = Convert.ToInt32(reader["id_patrulla"]);
                            string codigo = reader["codigo_patrulla"].ToString();
                            double latPatrulla = Convert.ToDouble(reader["latPatrulla"]);
                            double lngPatrulla = Convert.ToDouble(reader["lngPatrulla"]);
                            PointLatLng nuevaPos = new PointLatLng(latPatrulla, lngPatrulla);

                            // 1️⃣ Mover el marcador de la patrulla
                            var marker = markerPatrullas.Markers
                                .FirstOrDefault(m => m.ToolTipText.Contains(codigo));

                            if (marker != null)
                                marker.Position = nuevaPos;

                            // 2️⃣ Si tiene alerta asignada → actualizar ruta
                            if (reader["id_alerta"] != DBNull.Value)
                            {
                                int idAlerta = Convert.ToInt32(reader["id_alerta"]);
                                string direccion = reader["direccion"].ToString();

                                // Eliminar ruta vieja
                                string nombreRuta = $"Ruta_P{idPatrulla}_A{idAlerta}";
                                EliminarRutaPorNombre(nombreRuta);

                                // Obtener nueva posición de alerta (usa tu función)
                                PointLatLng posAlerta = ObtenerCoordenadasAlerta(idAlerta);

                                // Recalcular ruta con tu algoritmo de Dijkstra
                                CalcularRuta(nuevaPos, posAlerta, nombreRuta, Color.Blue);
                            }
                        }
                    }
                }
            }

            gMapControl1.Update();
        }



        private bool validacionesFormulario()
        {
            string direccion = textDireccion.Text.Trim();
            string telefono = textTelefono.Text.Trim();
            string nombre = textNombre.Text.Trim();

            if (string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("El campo Dirección es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            // Dirección: letras, números, espacios, ñ y acentos
            if (!Regex.IsMatch(direccion, @"^[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ\s]+$"))
            {
                MessageBox.Show("La dirección no puede contener caracteres especiales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Nombre: solo letras, ñ y acentos
            if (!string.IsNullOrEmpty(nombre) && !Regex.IsMatch(nombre, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$"))
            {
                MessageBox.Show("El nombre solo puede contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            // Validar que teléfono (si no está vacío) contenga solo números
            if (!string.IsNullOrEmpty(telefono) && !Regex.IsMatch(telefono, @"^\d+$"))
            {
                MessageBox.Show("El teléfono solo puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que haya al menos un delito seleccionado
            if (ListDelitos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar al menos un delito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo letras, espacio y tecla de borrado
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void textTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números y tecla de borrado
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Letras, números, espacios y tecla de borrado
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        // -----------------------------
        // Cambios al agregar nueva alerta: boton btnAgregarAlerta_Click
        // - Capturamos el id_insertado y colocamos en el marker.Tag: "Alerta|{id}"
        // -----------------------------
        private void btnAgregarAlerta_Click(object sender, EventArgs e)
        {
            if (!validacionesFormulario()) return;

            string direccion = textDireccion.Text.Trim();
            string telefono = textTelefono.Text.Trim();
            string nombre = textNombre.Text.Trim();
            string delito = ListDelitos.SelectedItem.ToString();
            DateTime fechaCreacion = DateTime.Now;
            string estado = "En Espera";
            string tipoIncidencia = delito;
            int idUsuario = FormLogin.Sesion.IdUsuario;
            int idCanal = 2;
            string importancia = ObtenerImportanciaPorColor(delito);
            string direccionCompleta = $"{direccion}, Corrientes Capital, Corrientes, Argentina";

            // Geocodificar dirección
            GeoCoderStatusCode status;
            var point = GMapProviders.OpenStreetMap.GetPoint(direccionCompleta, out status);

            if (status == GeoCoderStatusCode.G_GEO_SUCCESS && point != null)
            {
                int idAlerta;
                using (SqlConnection conn = Database.GetConnection())
                {
                    string insertAlertaQuery = @"
                INSERT INTO Alerta (estado, importancia, tipo_incidencia, direccion, fecha_cierre, id_usuario, id_canal)
                OUTPUT INSERTED.id_alerta
                VALUES (@estado, @importancia, @tipo_incidencia, @direccion, NULL, @id_usuario, @id_canal)";

                    using (SqlCommand cmdAlerta = new SqlCommand(insertAlertaQuery, conn))
                    {
                        cmdAlerta.Parameters.AddWithValue("@estado", estado);
                        cmdAlerta.Parameters.AddWithValue("@importancia", importancia);
                        cmdAlerta.Parameters.AddWithValue("@tipo_incidencia", tipoIncidencia);
                        cmdAlerta.Parameters.AddWithValue("@direccion", direccion);
                        cmdAlerta.Parameters.AddWithValue("@id_usuario", idUsuario);
                        cmdAlerta.Parameters.AddWithValue("@id_canal", idCanal);

                        idAlerta = (int)cmdAlerta.ExecuteScalar();
                    }

                    string insertLlamadaQuery = @"
                INSERT INTO Llamada (fecha_creacion, nombre, telefono, id_alerta)
                VALUES (@fecha_creacion, @nombre, @telefono, @id_alerta)";

                    using (SqlCommand cmdLlamada = new SqlCommand(insertLlamadaQuery, conn))
                    {
                        cmdLlamada.Parameters.AddWithValue("@fecha_creacion", fechaCreacion);
                        cmdLlamada.Parameters.AddWithValue("@nombre", nombre);
                        cmdLlamada.Parameters.AddWithValue("@telefono", telefono);
                        cmdLlamada.Parameters.AddWithValue("@id_alerta", idAlerta);
                        cmdLlamada.ExecuteNonQuery();
                    }
                }

                // Refrescar grilla (asegúrate que CargarAlertas rellene una columna oculta "id_alerta")
                CargarAlertas();

                // Mostrar en el mapa y marcar el id en Tag
                gMapControl1.Position = point.Value;
                gMapControl1.Zoom = 16;

                var marker = new GMarkerGoogle(point.Value, GMarkerGoogleType.red)
                {
                    // Guardamos el id real en el Tag para evitar buscar por texto
                    Tag = $"Alerta|{idAlerta}",
                    ToolTipText = $"{delito}, {direccion}",
                    ToolTipMode = MarkerTooltipMode.OnMouseOver
                };
                markerAlertas.Markers.Add(marker);
            }
            else
            {
                MessageBox.Show("No se encontró la dirección.");
            }
        }


        private void ListDelitos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < ListDelitos.Items.Count; i++)
                {
                    if (i != e.Index)
                        ListDelitos.SetItemChecked(i, false);
                }
            }
        }

        private void PintarFila(int rowIndex, string delito)
        {
            
            if (rowIndex < 0 || rowIndex >= dataGridViewAlertas.Rows.Count)
            {
                return;
            }
            DataGridViewRow filaActual = dataGridViewAlertas.Rows[rowIndex];

            string delitoLimpio = delito.Trim();
            if (coloresDelitos.ContainsKey(delitoLimpio))
            {
                Color colorDeFondo = coloresDelitos[delitoLimpio];
                filaActual.DefaultCellStyle.BackColor = colorDeFondo;
                Color colorDeTexto = (colorDeFondo == Color.Red) ? Color.White : Color.Black;
                filaActual.DefaultCellStyle.ForeColor = colorDeTexto;
            }
            else
            { 
                filaActual.DefaultCellStyle.BackColor = Color.White;
                filaActual.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private string ObtenerImportanciaPorColor(string delito)
        {
            string delitoLimpio = delito.Trim();
            Color colorDeFondo = coloresDelitos[delitoLimpio];
            if (colorDeFondo == Color.Red)
            {
                return "Alta";
            }
            else if (colorDeFondo == Color.Yellow)
            {
                return "Media";
            }
            else { 
                return "Baja";
            }
        }

        private void btnBomberos_Click(object sender, EventArgs e)
        {
            if (bomberosVisibles)
            {
                markerBomberos.Markers.Clear();
                bomberosVisibles = false;
            }
            else
            {
                CargarBomberos();
                bomberosVisibles = true;
            }
            gMapControl1.Refresh();
        }

        private void btnHospitales_Click(object sender, EventArgs e)
        {
            if (hospitalesVisibles)
            {
                markerHospitales.Markers.Clear();
                hospitalesVisibles = false;
            }
            else
            {
                CargarHospitales();
                hospitalesVisibles = true;
            }
            gMapControl1.Refresh();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Seguro que desea cerrar sesión?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnActualizarMapa_Click(object sender, EventArgs e)
        {
            ActualizarUbicacionesYAlertas();
        }

        private void dataGridViewAlertas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

