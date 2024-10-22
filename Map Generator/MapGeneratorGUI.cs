using Blenordia.Source.Handlers;
using File = Blenordia.Source.Handlers.File;

namespace Map_Generator
{
    public partial class MapGeneratorGUI : Form
    {
        public MapGeneratorGUI()
        {
            InitializeComponent();
        }

        private void MapGeneratorGUI_Load(object sender, EventArgs e)
        {
            MapInfo TempMapInfo = new MapInfo("Temp Map");
            Map TempMap = Map.Create(TempMapInfo);



            TempMap.Info.File.WriteAllText("Hello World");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
