using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    /// <summary>
    /// Garante que a classe tenha somente uma instância e fornece um ponto de acesso global para ela
    /// </summary>
    public class SingletonExample
    {
        private Service _service;
        public Service Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new Service();
                }

                return _service;
            }
        }        

        public void RunExample()
        {
            Service.Method(); // Na primeira utilização da propriedade Service será criada uma instância
            Service.Method(); // Nessa e nas demais utilizações da propriedade Service a instância já terá sido criada
            Service.Method();

            Console.Read();
        }
    }
}
