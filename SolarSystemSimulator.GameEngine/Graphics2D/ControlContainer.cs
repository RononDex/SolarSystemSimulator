using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics2D
{
    /// <summary>
    /// A container for UI controls
    /// </summary>
    public class ControlContainer : IEnumerable<Control>
    {
        private List<Control> controlsList = new List<Control>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Control this[string id]
        {
            get { return this.FindControlByID(id); }
        }

        /// <summary>
        /// Searches for the control with the given ID. Returns NULL if not found
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Control FindControlByID(string ID)
        {
            foreach (Control control in this.controlsList)
            {
                if (control.ID == ID)
                    return control;
            }

            return null;
        }

        /// <summary>
        /// Adds the given control to the container
        /// </summary>
        /// <param name="control"></param>
        public void AddControl(Control control)
        {
            var existingControl = FindControlByID(control.ID);
            if (existingControl != null)
                throw new InvalidOperationException(string.Format("A control with the ID {0} already exists!", control.ID));

            this.controlsList.Add(control);
        }

        public IEnumerator<Control> GetEnumerator()
        {
            return this.controlsList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.controlsList.GetEnumerator();
        }
    }
}
