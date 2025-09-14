using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class BenutzerViewModel
{
        public int Id { get; set; }
        public string Benutzername { get; set; }
        public int RolleId { get; set; }  // Bindet an ComboBox
    }
}
