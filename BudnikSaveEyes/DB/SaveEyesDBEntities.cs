using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudnikSaveEyes.DB
{
    public partial class SaveEyesDBEntities
    {
        private static SaveEyesDBEntities _context;

        public static SaveEyesDBEntities GetContext()
        {
            if (_context == null )
                _context = new SaveEyesDBEntities();

            return _context;
        }
    }
}
