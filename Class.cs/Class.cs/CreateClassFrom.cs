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
    public partial class CreateClassFrom : Form
    {
        private ClassManagement business;
        public CreateClassFrom()
        {
            InitializeComponent();
            this.business = new ClassManagement();
            this.btnCancel.Click += btnCancel_Click;
            this.btnSave.Click += btnSave_Click;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var name=this.txtName.Text;
            var desciption = this.txtDescription.Text;
            this.business.AddClass(name, desciption);
            MessageBox.Show("Create class successfully.");
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
