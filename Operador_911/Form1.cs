using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Operador_911
{
    public partial class Form1 : Form
    {
        GMapOverlay markerOverlay;
        GMapOverlay polygonOverlay;
        DataTable dt;
        private bool jurisdiccionesVisibles = true;

        // Variable para guardar los límites
        private RectLatLng mapBounds;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            gMapControl1.Dock = DockStyle.Fill;

            // Configuración del panel
            panelNavegacion.Dock = DockStyle.Top;
            panelNavegacion.Height = 50;
            panelNavegacion.BackColor = Color.DodgerBlue;

            // Configuración del mapa
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            // Centro en Corrientes Capital
            gMapControl1.Position = new PointLatLng(-27.4692, -58.8306);
            gMapControl1.MinZoom = 13;
            gMapControl1.MaxZoom = 19;
            gMapControl1.Zoom = 14;

            CargarJurisdicciones();
            CargarMarkers();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            gMapControl1.OnPositionChanged += gMapControl1_OnPositionChanged;

        }

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

        private void gMapControl1_OnPositionChanged(PointLatLng point)
        {
            // Actualiza los TextBox con la posición del centro del mapa (cruz roja)
            textLatitud.Text = point.Lat.ToString();
            textLongitud.Text = point.Lng.ToString();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            // Copia Latitud y Longitud juntas, separadas por coma
            string coordenadas = $"{textLatitud.Text}, {textLongitud.Text}";
            Clipboard.SetText(coordenadas);

            
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

            GMapPolygon polygon7 = new GMapPolygon(puntosComisaria7, "Comisaría 7ma");
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
            gMapControl1.Overlays.Add(markerOverlay);
        }

    }
}
