using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepreciationDBApp.Forms
{
    public partial class Form1 : Form
    {
        private IAssetService assetService;

        public Form1(IAssetService assetService)
        {
            this.assetService = assetService;
            InitializeComponent();
        }

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            Asset asset = new Asset()
            {
                Name = "Monitor",
                Description = "Dell 24 pulgadas 4k",
                Amount = 22433.33M,
                AmountResidual = 0,
                Terms = 2,
                Code = Guid.NewGuid().ToString(),
                Status = "Disponible",
                IsActive = true
            };

            assetService.Create(asset);
            LoadDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dgvAsset.DataSource = assetService.GetAll();
        }
    }
}
