using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private PersonModel model;

        public Form1()
        {
            InitializeComponent();
        }

        void UpdatePersonEntity(PersonModel model)
        {
            var person = GetPersonEntity(model.Id);
            ApplyChanges(person, model);
            Save(person);
        }

        private PersonEntity GetPersonEntity(object id)
        {
            throw new NotImplementedException();
        }
        private void ApplyChanges(PersonEntity person, PersonModel model)
        {
            throw new NotImplementedException();
        }

        private static void Save(PersonEntity person)
        {
            throw new NotImplementedException();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpdatePersonEntity(model); // shouldn't show any error dialogs
            }
            catch (Exception ex)
            {
                // show error dialog
            }
        }
    }
}
