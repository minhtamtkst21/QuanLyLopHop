using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class.cs
{
    public partial class IndexClassForm : Form
    {
        private ClassManagement Bussiness;
        public IndexClassForm()
        {
            InitializeComponent();
            this.Bussiness = new ClassManagement();
            this.Load += IndexClassForm_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdClasses.DoubleClick += grdClasses_DoubleClick;
        }

        void grdClasses_DoubleClick(object sender, EventArgs e)
        {
           var @class = (Class)this.grdClasses.SelectedRows[0].DataBoundItem;
           var updateForm = new updateClassForm(@class.id);
           updateForm.ShowDialog();
           this.loadAllClasses();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grdClasses.SelectedRows.Count == 1)
            {
                if(MessageBox.Show("Do you want to Delete this?","Confirm",
                    MessageBoxButtons.YesNo) 
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    var @class =(Class)this.grdClasses.SelectedRows[0].DataBoundItem;
                    this.Bussiness.DeleteClass(@class.id);
                    MessageBox.Show("Delete class successfully");
                    this.loadAllClasses();
                }
            }
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateClassFrom();
            createForm.ShowDialog();
            this.loadAllClasses();
        }

        void IndexClassForm_Load(object sender, EventArgs e)
        {
            this.loadAllClasses();

        }

        private void loadAllClasses()
        {
            var classes = this.Bussiness.GetClasses();
            this.grdClasses.DataSource = classes;
        }
    }
}
