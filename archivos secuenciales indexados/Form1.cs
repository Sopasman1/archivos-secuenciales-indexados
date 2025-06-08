namespace archivos_secuenciales_indexados
{
    public partial class Form1 : Form
    {
        private string gameDataFile = "games.txt";
        private List<string> brands = new List<string> { "Nintendo", "Sony", "Microsoft", "Sega", "Capcom", "EA", "Ubisoft", "Square Enix" };
        public Form1()
        {
            InitializeComponent();
            LoadBrands();
        }
        private void LoadBrands()
        {
            comboBoxBrand.DataSource = brands;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Game newGame = new Game
                {
                    Brand = comboBoxBrand.SelectedItem.ToString(),
                    Name = txtName.Text,
                    Price = decimal.Parse(txtPrice.Text)
                };

                RegisterGame(newGame);
                ClearFields();
                MessageBox.Show("Game registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void RegisterGame(Game game)
        {
            using (StreamWriter writer = new StreamWriter(gameDataFile, true))
            {
                writer.WriteLine($"{game.Brand}|{game.Name}|{game.Price}");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            listBoxGames.Items.Clear();

            if (File.Exists(gameDataFile))
            {
                using (StreamReader reader = new StreamReader(gameDataFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        listBoxGames.Items.Add(line);
                    }
                }
                MessageBox.Show($"Games loaded: {listBoxGames.Items.Count}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No games registered yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxGames.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a game to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this game?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string selectedGame = listBoxGames.SelectedItem.ToString();
                List<string> remainingGames = new List<string>();

                // Read all games except the selected one
                using (StreamReader reader = new StreamReader(gameDataFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != selectedGame)
                        {
                            remainingGames.Add(line);
                        }
                    }
                }

                // Overwrite file with remaining games
                using (StreamWriter writer = new StreamWriter(gameDataFile, false))
                {
                    foreach (string game in remainingGames)
                    {
                        writer.WriteLine(game);
                    }
                }

                MessageBox.Show("Game deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLoad_Click(sender, e); // Reload the list
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter a name to search", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxGames.Items.Clear();
            string searchTerm = txtSearch.Text.ToLower();

            if (File.Exists(gameDataFile))
            {
                using (StreamReader reader = new StreamReader(gameDataFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts[1].ToLower().Contains(searchTerm))
                        {
                            listBoxGames.Items.Add(line);
                        }
                    }
                }

                if (listBoxGames.Items.Count == 0)
                {
                    MessageBox.Show("No games found with that name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No games registered yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtPrice.Clear();
            comboBoxBrand.SelectedIndex = 0;
            txtName.Focus();
        }
    }
}
