using System.Drawing.Imaging;

namespace archivos_secuenciales_indexados
{
    public partial class Form1 : Form
    {
        private string DataFile = "games.dat";
        private const string IndexFile = "games.idx";
        private readonly List<string> brands = new List<string> { "Nintendo", "Sony", "Microsoft", "Sega", "Capcom", "EA", "Ubisoft", "Square Enix" };

        public Form1()
        {
            InitializeComponent();
            LoadBrands();
            InitializeFiles();
        }
        private void InitializeFiles()
        {
            if (!File.Exists(DataFile)) File.Create(DataFile).Close();
            if (!File.Exists(IndexFile)) File.Create(IndexFile).Close();
        }

        private void LoadBrands()
        {
            cmbBrand.DataSource = brands.ToList();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                var game = new Game
                {
                    ID = GenerateID(),
                    Brand = cmbBrand.SelectedItem.ToString(),
                    Name = txtName.Text,
                    Price = decimal.Parse(txtPrice.Text)
                };

                AddRecord(game);
                ClearFields();
                MessageBox.Show("Game registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int GenerateID()
        {
            if (!File.Exists(DataFile) || new FileInfo(DataFile).Length == 0)
                return 1;

            var lastLine = File.ReadLines(DataFile).Last();
            var parts = lastLine.Split('|');
            return int.Parse(parts[0]) + 1;
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the game name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void AddRecord(Game game)
        {
            // Add to data file
            using (var writer = new StreamWriter(DataFile, true))
            {
                writer.WriteLine($"{game.ID}|{game.Brand}|{game.Name}|{game.Price}");
            }

            // Update index file
            using (var writer = new StreamWriter(IndexFile, true))
            {
                writer.WriteLine($"{game.ID}|{GetByteOffset(game.ID)}");
            }
        }

        private long GetByteOffset(int id)
        {
            if (!File.Exists(DataFile)) return 0;

            using (var reader = new StreamReader(DataFile))
            {
                long offset = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith(id.ToString()))
                        return offset;
                    offset += line.Length + Environment.NewLine.Length;
                }
            }
            return 0;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            lstGames.Items.Clear();

            if (!File.Exists(DataFile) || new FileInfo(DataFile).Length == 0)
            {
                MessageBox.Show("No games registered yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var line in File.ReadLines(DataFile))
            {
                lstGames.Items.Add(line);
            }

            lblStatus.Text = $"{lstGames.Items.Count} games loaded";
        }

       

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (lstGames.SelectedItem == null)
            {
                MessageBox.Show("Please select a game to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedGame = lstGames.SelectedItem.ToString();
            var id = int.Parse(selectedGame.Split('|')[0]);

            if (MessageBox.Show("Are you sure you want to delete this game?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteRecord(id);
                btnLoad_Click(sender, e); // Refresh list
                MessageBox.Show("Game deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void DeleteRecord(int id)
        {
            // Create temporary files
            var tempData = Path.GetTempFileName();
            var tempIndex = Path.GetTempFileName();

            // Copy all records except the one to delete
            using (var writer = new StreamWriter(tempData))
            using (var reader = new StreamReader(DataFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.StartsWith(id.ToString()))
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            // Rebuild index file
            using (var writer = new StreamWriter(tempIndex))
            using (var reader = new StreamReader(tempData))
            {
                long offset = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var currentId = int.Parse(line.Split('|')[0]);
                    writer.WriteLine($"{currentId}|{offset}");
                    offset += line.Length + Environment.NewLine.Length;
                }
            }

            // Replace original files
            File.Delete(DataFile);
            File.Delete(IndexFile);
            File.Move(tempData, DataFile);
            File.Move(tempIndex, IndexFile);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter a search term", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var searchTerm = txtSearch.Text.ToLower();
            lstGames.Items.Clear();

            if (!File.Exists(DataFile) || new FileInfo(DataFile).Length == 0)
            {
                MessageBox.Show("No games registered yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var line in File.ReadLines(DataFile))
            {
                var parts = line.Split('|');
                if (parts[2].ToLower().Contains(searchTerm)) // Name is at index 2
                {
                    lstGames.Items.Add(line);
                }
            }

            lblStatus.Text = $"Found {lstGames.Items.Count} matches";

        }
        private void ClearFields()
        {
            txtName.Clear();
            txtPrice.Clear();
            cmbBrand.SelectedIndex = 0;
            txtName.Focus();
        }

    }

}
