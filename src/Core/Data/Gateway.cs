using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class Gateway
    {
        private readonly PortalDbContext _context;

        public Gateway(PortalDbContext context)
        {
            _context = context;
        }

        //AQUI EMBAIXO VÃO OS MÉTODOS DE CRIAR/REGISTRAR ETC DE CADA MODEL PARA NÃO FICAR NO CONTROLADOR
    }
}