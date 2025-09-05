using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Operador_911
{
    public partial class Form1 : Form
    {
        GMapOverlay markerOverlay;
        GMapOverlay polygonOverlay;
        private bool jurisdiccionesVisibles = true;

        // Variable para guardar los límites
        private RectLatLng mapBounds;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            gMapControl1.Dock = DockStyle.Fill;

            // Panel navegación arriba
            panelNavegacion.Dock = DockStyle.Top;
            panelNavegacion.Height = 50;
            panelNavegacion.BackColor = Color.DodgerBlue;

            // Panel mapa a la izquierda
            panelMapa.Dock = DockStyle.Left;
            panelMapa.Width = 960; // ancho fijo para el mapa

            // Panel formulario a la derecha (ocupa lo que sobra)
            panelForm.Dock = DockStyle.Fill;

            // Configuración del mapa
            gMapControl1.Parent = panelMapa;
            gMapControl1.Dock = DockStyle.Fill;
            // Configuración del mapa
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            // Centro en Corrientes Capital
            gMapControl1.Position = new PointLatLng(-27.4692, -58.8306);
            gMapControl1.MinZoom = 12;
            gMapControl1.MaxZoom = 19;
            gMapControl1.Zoom = 14;


            CargarJurisdicciones();
            CargarMarkers();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


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


        private void btnJurisdicciones_Click(object sender, EventArgs e)
        {
            if (jurisdiccionesVisibles)
            {
                // Ocultar todas las jurisdicciones
                polygonOverlay.Polygons.Clear();
                // Si también querés ocultar los marcadores de comisarías:
                markerOverlay.Markers.Clear();

                jurisdiccionesVisibles = false;

            }
            else
            {
                // Volver a cargar las jurisdicciones y marcadores
                CargarJurisdicciones(); // 👉 función donde tenés tu código de creación de polígonos
                CargarMarkers();        // 👉 si los querés manejar aparte

                jurisdiccionesVisibles = true;

            }

            gMapControl1.Refresh(); // refresca el mapa
        }





        private void CargarJurisdicciones()
        {
            // ----------------- OVERLAY PARA POLÍGONOS -----------------
            polygonOverlay = new GMapOverlay("jurisdicciones");

            // Polígono irregular de la Comisaría 1ra
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
            GMapPolygon polygon1 = new GMapPolygon(puntosComisaria1, "Jurisdicción Comisaría 1ra");
            polygon1.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon1.Stroke = new Pen(Color.Red, 2);
            polygonOverlay.Polygons.Add(polygon1);

            // Polígono irregular de la Comisaría 4ta
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
                new PointLatLng(-27.460508, -58.834946) // cerramos polígono
            };
            GMapPolygon polygon4 = new GMapPolygon(puntosComisaria4, "Jurisdicción Comisaría 4ta");
            polygon4.Fill = new SolidBrush(Color.FromArgb(50, Color.Green));
            polygon4.Stroke = new Pen(Color.Green, 2);
            polygonOverlay.Polygons.Add(polygon4);

            // Polígono de la jurisdicción que incluye ambas comisarías
            List<PointLatLng> puntosJurisdiccion = new List<PointLatLng>()
        {
            new PointLatLng(-27.469912, -58.835807),
            new PointLatLng(-27.485333, -58.837662),
            new PointLatLng(-27.485715, -58.834181),
            new PointLatLng(-27.483202, -58.825832),
            new PointLatLng(-27.484662, -58.824536),
            new PointLatLng(-27.471153, -58.823088),
            new PointLatLng(-27.469912, -58.835807) // cerramos polígono
        };

            GMapPolygon polygonJurisdiccion = new GMapPolygon(puntosJurisdiccion, "Jurisdicción Comisaría 1ra Mujer y 3ra");
            polygonJurisdiccion.Fill = new SolidBrush(Color.FromArgb(50, Color.Purple));
            polygonJurisdiccion.Stroke = new Pen(Color.Purple, 2);
            polygonOverlay.Polygons.Add(polygonJurisdiccion);

            // Polígono de jurisdicción Comisaría 2
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

            GMapPolygon polygon3 = new GMapPolygon(puntosComisaria2, "Comisaría 2da");
            polygon3.Fill = new SolidBrush(Color.FromArgb(50, Color.Orange));
            polygon3.Stroke = new Pen(Color.Orange, 2);
            polygonOverlay.Polygons.Add(polygon3);


            // Polígono de jurisdicción Comisaría 12
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

            GMapPolygon polygon12 = new GMapPolygon(puntosComisaria12, "Jurisdicción Comisaría 12");
            polygon12.Fill = new SolidBrush(Color.FromArgb(50, Color.Violet));
            polygon12.Stroke = new Pen(Color.Violet, 2);
            polygonOverlay.Polygons.Add(polygon12);

            // Polígono de jurisdicción Comisaría 7
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

            GMapPolygon polygon7 = new GMapPolygon(puntosComisaria7, "Jurisdicción Comisaría 7ma");
            polygon7.Fill = new SolidBrush(Color.FromArgb(50, Color.Brown));
            polygon7.Stroke = new Pen(Color.Brown, 2);
            polygonOverlay.Polygons.Add(polygon7);

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
                new PointLatLng(-27.4558073943475, -58.8213801383972) // cierre del polígono
            };
            GMapPolygon polygon6 = new GMapPolygon(puntosComisaria6, "Jurisdicción Comisaría 6ta");
            polygon6.Fill = new SolidBrush(Color.FromArgb(50, Color.Blue));
            polygon6.Stroke = new Pen(Color.Blue, 2);
            polygonOverlay.Polygons.Add(polygon6);


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
                new PointLatLng(-27.4666886883559, -58.8217529654503) // cierre del polígono
            };
            GMapPolygon polygonContravencional = new GMapPolygon(puntosComisariaContravencional, "Jurisdicción Comisaría Contravencional");
            polygonContravencional.Fill = new SolidBrush(Color.FromArgb(50, Color.Aqua));
            polygonContravencional.Stroke = new Pen(Color.Aqua, 2);
            polygonOverlay.Polygons.Add(polygonContravencional);

            // Polígono irregular de la Comisaría 19
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
                new PointLatLng(-27.4745657702835, -58.8234427571297) // cierre del polígono
            };
            GMapPolygon polygonComisaria19 = new GMapPolygon(puntosComisaria19, "Jurisdicción Comisaría 19");
            polygonComisaria19.Fill = new SolidBrush(Color.FromArgb(50, Color.BlueViolet));
            polygonComisaria19.Stroke = new Pen(Color.BlueViolet, 2);
            polygonOverlay.Polygons.Add(polygonComisaria19);

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
                    new PointLatLng(-27.4681213596460, -58.7960225343704) // cierre del polígono
                };
            GMapPolygon polygon9 = new GMapPolygon(puntosComisaria9, "Jurisdicción Comisaría 9na");
            polygon9.Fill = new SolidBrush(Color.FromArgb(50, Color.Orange));
            polygon9.Stroke = new Pen(Color.Orange, 2);
            polygonOverlay.Polygons.Add(polygon9);

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
                    new PointLatLng(-27.4672384365180, -58.8097608089447) // cierre del polígono
                };
            GMapPolygon polygon11 = new GMapPolygon(puntosComisaria11, "Jurisdicción Comisaría 11ra");
            polygon11.Fill = new SolidBrush(Color.FromArgb(50, Color.Purple));
            polygon11.Stroke = new Pen(Color.Purple, 2);
            polygonOverlay.Polygons.Add(polygon11);

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
            GMapPolygon polygon15 = new GMapPolygon(puntosComisaria15, "Jurisdicción Comisaría 15ta");
            polygon15.Fill = new SolidBrush(Color.FromArgb(50, Color.DarkBlue));
            polygon15.Stroke = new Pen(Color.DarkBlue, 2);
            polygonOverlay.Polygons.Add(polygon15);

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
            GMapPolygon polygon8 = new GMapPolygon(puntosComisaria8, "Jurisdicción Comisaría 8va");
            polygon8.Fill = new SolidBrush(Color.FromArgb(50, Color.DarkGreen));
            polygon8.Stroke = new Pen(Color.DarkGreen, 2);
            polygonOverlay.Polygons.Add(polygon8);

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

            GMapPolygon polygon21 = new GMapPolygon(puntosComisaria21, "Jurisdicción Comisaría 21ra");
            polygon21.Fill = new SolidBrush(Color.FromArgb(50, Color.Yellow));
            polygon21.Stroke = new Pen(Color.Yellow, 2);
            polygonOverlay.Polygons.Add(polygon21);

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

            GMapPolygon polygon14 = new GMapPolygon(puntosComisaria14, "Jurisdicción Comisaría 14ta");
            polygon14.Fill = new SolidBrush(Color.FromArgb(50, Color.DarkMagenta));
            polygon14.Stroke = new Pen(Color.DarkMagenta, 2);
            polygonOverlay.Polygons.Add(polygon14);

            // Polígono delimitando la jurisdicción
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

            GMapPolygon poligonoComisaria13 = new GMapPolygon(puntosComisaria13, "Jurisdicción Comisaría 13ra");
            poligonoComisaria13.Fill = new SolidBrush(Color.FromArgb(50, Color.Black));
            poligonoComisaria13.Stroke = new Pen(Color.Black, 2);
            polygonOverlay.Polygons.Add(poligonoComisaria13);

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

            GMapPolygon poligonoRiachuelo = new GMapPolygon(puntosRiachuelo, "Jurisdicción Comisaria Riachuelo");
            poligonoRiachuelo.Fill = new SolidBrush(Color.FromArgb(50, Color.DarkOliveGreen));
            poligonoRiachuelo.Stroke = new Pen(Color.DarkOliveGreen, 2);
            polygonOverlay.Polygons.Add(poligonoRiachuelo);

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

            GMapPolygon poligonoComisaria18yMujer = new GMapPolygon(puntosComisaria18yMujer, "Jurisdicción Comisaria 18 y 2da de la Mujer y el Menor");
            poligonoComisaria18yMujer.Fill = new SolidBrush(Color.FromArgb(50, Color.DarkOrange));
            poligonoComisaria18yMujer.Stroke = new Pen(Color.DarkOrange, 2);
            polygonOverlay.Polygons.Add(poligonoComisaria18yMujer);

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

            GMapPolygon poligonoComisaria20 = new GMapPolygon(puntosComisaria20, "Jurisdicción Comisaria 20");
            poligonoComisaria20.Fill = new SolidBrush(Color.FromArgb(50, Color.Crimson));
            poligonoComisaria20.Stroke = new Pen(Color.Crimson, 2);
            polygonOverlay.Polygons.Add(poligonoComisaria20);

            // ---------------- Polígono irregular de la Comisaría 16ta ----------------
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
                new PointLatLng(-27.4612148557966, -58.768036365509) // cerramos polígono
            };

            GMapPolygon polygon16 = new GMapPolygon(puntosComisaria16, "Jurisdicción Comisaría 16ta");
            polygon16.Fill = new SolidBrush(Color.FromArgb(50, Color.Olive));
            polygon16.Stroke = new Pen(Color.Olive, 2);
            polygonOverlay.Polygons.Add(polygon16);

            // ---------------- Polígono irregular de la Comisaría 10ma ----------------
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

            GMapPolygon polygon10 = new GMapPolygon(puntosComisaria10, "Jurisdicción Comisaría 10ma");
            polygon10.Fill = new SolidBrush(Color.FromArgb(50, Color.Purple));
            polygon10.Stroke = new Pen(Color.Purple, 2);
            polygonOverlay.Polygons.Add(polygon10);

            // ---------------- Polígono irregular de la Comisaría 17ma ----------------
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
                new PointLatLng(-27.4539223366493, -58.7911033630371) // cerramos polígono
            };

            GMapPolygon polygon17 = new GMapPolygon(puntosComisaria17, "Jurisdicción Comisaría 17ma");
            polygon17.Fill = new SolidBrush(Color.FromArgb(50, Color.Blue));
            polygon17.Stroke = new Pen(Color.Blue, 2);
            polygonOverlay.Polygons.Add(polygon17);

            // ----------------- AGREGAMOS OVERLAYS AL MAPA -----------------
            gMapControl1.Overlays.Add(polygonOverlay);
        }

        private void CargarMarkers()
        {
            // ----------------- OVERLAY PARA MARKERS -----------------
            markerOverlay = new GMapOverlay("markers");

            // Marker de la Comisaría 1ra
            PointLatLng comisaria1 = new PointLatLng(-27.468517, -58.841793);
            GMarkerGoogle marker1 = new GMarkerGoogle(comisaria1, GMarkerGoogleType.blue_dot);
            marker1.ToolTipText = "Comisaría 1ra\nDirección: Tucumán N°1028 - B° Deportes\nTel: 379-4424502";
            markerOverlay.Markers.Add(marker1);

            // Marker de la Comisaría 4ta
            PointLatLng comisaria4 = new PointLatLng(-27.460246, -58.827128);
            GMarkerGoogle marker4 = new GMarkerGoogle(comisaria4, GMarkerGoogleType.blue_dot);
            marker4.ToolTipText = "Comisaría 4ta\nDirección: Alvear N°1802 - B° Aldana\nTel: 379-4424518";
            markerOverlay.Markers.Add(marker4);

            // Marker de la Comisaría 1ra. de la Mujer y el Menor
            PointLatLng comisariaMujerMenor = new PointLatLng(-27.474024, -58.833750);
            GMarkerGoogle markerMujerMenor = new GMarkerGoogle(comisariaMujerMenor, GMarkerGoogleType.blue_dot);
            markerMujerMenor.ToolTipText = "Comisaría 1ra. de la Mujer y el Menor\nDirección: Calle Catamarca N°1445 - Bº Centro\nTel: 379-4432913";
            markerOverlay.Markers.Add(markerMujerMenor);

            // Marker de la Comisaría 3ra
            PointLatLng comisaria3ra = new PointLatLng(-27.476074, -58.831420);
            GMarkerGoogle marker3ra = new GMarkerGoogle(comisaria3ra, GMarkerGoogleType.blue_dot);
            marker3ra.ToolTipText = "Comisaría 3ra\nDirección: Santa Fe N°1575 - B° Centro\nTel: 379-4421272";
            markerOverlay.Markers.Add(marker3ra);

            // ---------------- Comisaría 2da ----------------
            PointLatLng comisaria2 = new PointLatLng(-27.480499, -58.845120);
            GMarkerGoogle marker2 = new GMarkerGoogle(comisaria2, GMarkerGoogleType.blue_dot);
            marker2.ToolTipText = "Comisaría 2da\nDirección: Av. Juan Bautista Alberdi N° 2084 - B° San Martín\nTel: 379-4421149";
            markerOverlay.Markers.Add(marker2);

            // ---------------- Comisaría 12da ----------------
            PointLatLng comisaria12 = new PointLatLng(-27.490683, -58.844033);
            GMarkerGoogle marker12 = new GMarkerGoogle(comisaria12, GMarkerGoogleType.blue_dot);
            marker12.ToolTipText = "Comisaría 12da\nDirección: Diego de Irala y Cabeza de Vaca - B° Juan de Vera\nTel: 379-4444649";
            markerOverlay.Markers.Add(marker12);

            // ---------------- Comisaría 7ma ----------------
            PointLatLng comisaria7 = new PointLatLng(-27.493629, -58.832291);
            GMarkerGoogle marker7 = new GMarkerGoogle(comisaria7, GMarkerGoogleType.blue_dot);
            marker7.ToolTipText = "Comisaría 7ma\nDirección: José Manuel Estrada (Esq. Calle Cosquin) - B° 1.000Vivdas\nTel: 379-4443304";
            markerOverlay.Markers.Add(marker7);

            // ---------------- Comisaría 6ta ----------------
            PointLatLng comisaria6 = new PointLatLng(-27.461791, -58.816690);
            GMarkerGoogle marker6 = new GMarkerGoogle(comisaria6, GMarkerGoogleType.blue_dot);
            marker6.ToolTipText = "Comisaría 6ta\nDirección: José María Rolón N° 2590 - B° Bañado Norte\nTel: 319-4422825";
            markerOverlay.Markers.Add(marker6);

            // ---------------- Comisaría Contravencional ----------------
            PointLatLng comisariaContravencional = new PointLatLng(-27.471607, -58.810639);
            GMarkerGoogle markerContravencional = new GMarkerGoogle(comisariaContravencional, GMarkerGoogleType.blue_dot);
            markerContravencional.ToolTipText = "Comisaría Contravencional\nDirección: Av. Centenario N° 3200 (casi calle Reconquista) - B° Hipódromo\nTel: 379-4474058";
            markerOverlay.Markers.Add(markerContravencional);

            // ---------------- Comisaría 19 ----------------
            PointLatLng comisaria19 = new PointLatLng(-27.480988, -58.817582);
            GMarkerGoogle markerComisaria19 = new GMarkerGoogle(comisaria19, GMarkerGoogleType.blue_dot);
            markerComisaria19.ToolTipText = "Comisaría 19na\nDirección: Chile y Pje. Castellanos - B° Tambor de Tacuarí\nTel: 379-4475445";
            markerOverlay.Markers.Add(markerComisaria19);

            // ---------------- Comisaría 16 ----------------
            PointLatLng comisaria16 = new PointLatLng(-27.473535, -58.789226);
            GMarkerGoogle markerComisaria16 = new GMarkerGoogle(comisaria16, GMarkerGoogleType.blue_dot);
            markerComisaria16.ToolTipText = "Comisaría 16ta\nDirección: Domingo Lastra y Laplace S/N° - B° San Gerónimo\nTel: 379-4484656";
            markerOverlay.Markers.Add(markerComisaria16);

            // ---------------- Comisaría 9na ----------------
            PointLatLng comisaria9 = new PointLatLng(-27.457898, -58.787947);
            GMarkerGoogle marker9 = new GMarkerGoogle(comisaria9, GMarkerGoogleType.blue_dot);
            marker9.ToolTipText = "Comisaría 9na\nDirección: Murcia S/N° - B° Apipé\nTel: 379-4457681";
            markerOverlay.Markers.Add(marker9);

            // ---------------- Comisaría 11ra ----------------
            PointLatLng comisaria11 = new PointLatLng(-27.463190226718, -58.8063758611679);
            GMarkerGoogle marker11 = new GMarkerGoogle(comisaria11, GMarkerGoogleType.blue_dot);
            marker11.ToolTipText = "Comisaría 11ra\nDirección: Zacarias Sanchez S/N° - B° Quinta Ferré\nTel: 379-4421924";
            markerOverlay.Markers.Add(marker11);

            // ---------------- Comisaría 15ta ----------------
            PointLatLng comisaria15 = new PointLatLng(-27.515120, -58.828607);
            GMarkerGoogle marker15 = new GMarkerGoogle(comisaria15, GMarkerGoogleType.blue_dot);
            marker15.ToolTipText = "Comisaría 15ta.\nDirección: Mocoretá S/N° - B° Río Paraná\nTel: 379-4101568";
            markerOverlay.Markers.Add(marker15);

            // ---------------- Comisaría 8va ----------------
            PointLatLng comisaria8 = new PointLatLng(-27.490740, -58.803505);
            GMarkerGoogle marker8 = new GMarkerGoogle(comisaria8, GMarkerGoogleType.blue_dot);
            marker8.ToolTipText = "Comisaría 8va\nDirección:Larrea (Esq. Las Piedras) - B° Laguna Seca\nTel: 379-4451033";
            markerOverlay.Markers.Add(marker8);

            // Marker de la Comisaría 21ra
            PointLatLng comisaria21 = new PointLatLng(-27.499028, -58.803586);
            GMarkerGoogle marker21 = new GMarkerGoogle(comisaria21, GMarkerGoogleType.blue_dot);
            marker21.ToolTipText = "Comisaría 21ra\nDirección: Escocia y Berazategui - B° Parque Ingenieros Serantes (Zona conocida como B° La Olla)\nTel: 379-4124202";
            markerOverlay.Markers.Add(marker21);

            // Marker de la Comisaría Estación Terminal de Ómnibus
            PointLatLng comisariaTerminal = new PointLatLng(-27.498276, -58.815324);
            GMarkerGoogle markerTerminal = new GMarkerGoogle(comisariaTerminal, GMarkerGoogleType.blue_dot);
            markerTerminal.ToolTipText = "Comisaría Estación Terminal de Ómnibus\nDirección: Av. Maipú N° 2599 - Bº Villa Ongai\nTel: 379-485014";
            markerOverlay.Markers.Add(markerTerminal);

            // Marker de la Comisaría 14ta
            PointLatLng comisaria14 = new PointLatLng(-27.527650, -58.789281);
            GMarkerGoogle marker14 = new GMarkerGoogle(comisaria14, GMarkerGoogleType.blue_dot);
            marker14.ToolTipText = "Comisaría 14ta\nDirección: Hidalgo, entre calles Mariano Beodo y Garzon - B° Dr. Montaña\nTel: 379-4414593";
            markerOverlay.Markers.Add(marker14);

            // Marker de la Comisaría 13ra
            PointLatLng puntoComisaria13 = new PointLatLng(-27.504758, -58.782623);
            GMarkerGoogle markerComisaria13 = new GMarkerGoogle(puntoComisaria13, GMarkerGoogleType.blue_dot);
            markerComisaria13.ToolTipText = "Comisaría 13ra\nDirección: Calle N° 189, entre Suecia y Cuba - B° Nuestra Señora de la Asunción\nTeléfono: 379-4471860";
            markerOverlay.Markers.Add(markerComisaria13);

            // Marker de la Comisaría Riachuelo
            PointLatLng puntoComisariaRiachuelo = new PointLatLng(-27.583541, -58.746105);
            GMapMarker markerRiachuelo = new GMarkerGoogle(puntoComisariaRiachuelo, GMarkerGoogleType.blue_dot);
            markerRiachuelo.ToolTipText = "Comisaría Riachuelo\nDirección: Juan José Echazarreta e Isadora Villanueva\nTeléfono: 379-4485014";
            markerOverlay.Markers.Add(markerRiachuelo);

            // Marker de la Comisaría 18va
            PointLatLng comisaria18 = new PointLatLng(-27.488318, -58.783728);
            GMapMarker markerComisaria18 = new GMarkerGoogle(comisaria18, GMarkerGoogleType.blue_dot);
            markerComisaria18.ToolTipText = "Comisaría 18va\nDirección: Turín y el Trébol - B° 17 de Agosto\nTeléfono: 379-4484658";
            markerOverlay.Markers.Add(markerComisaria18);

            // Marker de la Comisaría 2da de la Mujer
            PointLatLng puntoComisaria2daMujer = new PointLatLng(-27.488216, -58.784457);
            GMapMarker markerComisaria2daMujer = new GMarkerGoogle(puntoComisaria2daMujer, GMarkerGoogleType.blue_dot);
            markerComisaria2daMujer.ToolTipText = "Comisaría 2da. De la Mujer y el Menor\nDirección: Calle Milán S/N° - B° 17 de Agosto\nTeléfono: 379-4485651";
            markerOverlay.Markers.Add(markerComisaria2daMujer);

            // Marker de la Comisaría 20da
            PointLatLng puntoComisaria20 = new PointLatLng(-27.519600, -58.779113);
            GMapMarker markerComisaria20 = new GMarkerGoogle(puntoComisaria20, GMarkerGoogleType.blue_dot);
            markerComisaria20.ToolTipText = "Comisaría 20da.\nDirección: 500 Viviendas. Lote 'A'. Mz 81 - B° Pirayui Nuevo\nTeléfono: 379-4470558";
            markerOverlay.Markers.Add(markerComisaria20);

            // ---------------- Comisaría 10 ----------------
            PointLatLng comisaria10 = new PointLatLng(-27.489529, -58.721392);
            GMarkerGoogle markerComisaria10 = new GMarkerGoogle(comisaria10, GMarkerGoogleType.blue_dot);
            markerComisaria10.ToolTipText = "Comisaría 10ma\nDirección: Ruta Provincial N° 5. Km 7 - B° Laguna Brava\nTel: 379-4495920";
            markerOverlay.Markers.Add(markerComisaria10);

            // ---------------- Comisaría 17 ----------------
            PointLatLng comisaria17 = new PointLatLng(-27.441618, -58.783901);
            GMarkerGoogle markerComisaria17 = new GMarkerGoogle(comisaria17, GMarkerGoogleType.blue_dot);
            markerComisaria17.ToolTipText = "Comisaría 17ma\nDirección: Saladas N° 5780 - B° Molina Punta\nTel: 379-4484657";
            markerOverlay.Markers.Add(markerComisaria17);

            gMapControl1.Overlays.Add(markerOverlay);
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


            // Validar que direccion no tenga caracteres especiales
            if (!Regex.IsMatch(direccion, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("La dirección no puede contener caracteres especiales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que nombre (si no está vacío) contenga solo letras
            if (!string.IsNullOrEmpty(nombre) && !Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$"))
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

        private void btnAgregarAlerta_Click(object sender, EventArgs e)
        {
            if (!validacionesFormulario()) return;

            string direccion = textDireccion.Text.Trim();
            string telefono = textTelefono.Text.Trim();
            string nombre = textNombre.Text.Trim();
            string delito = ListDelitos.SelectedItem.ToString();

            // Generar ID automático
            int id = dataGridView1.Rows.Count + 1;

            

            // Agregar la fila respetando el orden de las columnas
            int rowIndex = dataGridView1.Rows.Add(id, delito, "En Espera", telefono, nombre, direccion);

            // Colorear la fila según el tipo de delito
            PintarFila(rowIndex, delito);

            // Mostrar ubicación en el mapa
            string direccionCompleta = $"{direccion}, Corrientes Capital, Corrientes, Argentina";

            GeoCoderStatusCode status;
            var point = GMapProviders.OpenStreetMap.GetPoint(direccionCompleta, out status);

            if (status == GeoCoderStatusCode.G_GEO_SUCCESS && point != null)
            {
                gMapControl1.Position = point.Value;
                gMapControl1.Zoom = 16;

                var overlay = new GMapOverlay("markers");
                var marker = new GMarkerGoogle(point.Value, GMarkerGoogleType.red);
                overlay.Markers.Add(marker);

                gMapControl1.Overlays.Clear();
                gMapControl1.Overlays.Add(overlay);
            }
            else
            {
                MessageBox.Show($"No se encontró la dirección. Status: {status}");
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
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            delito = delito.Trim();

            if (coloresDelitos.ContainsKey(delito))
            {
                row.DefaultCellStyle.BackColor = coloresDelitos[delito];
                row.DefaultCellStyle.ForeColor = (coloresDelitos[delito] == Color.Red) ? Color.White : Color.Black;
            }
            else
            {
               
            }
        }


    }
}

