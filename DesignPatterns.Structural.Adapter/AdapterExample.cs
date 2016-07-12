using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter
{
    /// <summary>
    /// - Converte uma interface de uma classe em outra interface esperada pelos clientes.
    /// - Permite classes de trabalhar em conjunto em situações que não poderiam pela incompatibilidade de interfaces
    /// - Pode funcionar como um "wrapper"
    /// </summary>
    public class AdapterExample
    {
        public void RunExample()
        {
            // ShowMessage recebe obrigatoriamente um "LegacyMessage", mas precisamos enviar um "NewMessage"
            ShowMessage(new LegacyMessage());

            // Para tal se faz necessário um Adaptador
            ShowMessage(new AdapterMessage());

            Console.Read();
        }
        
        public void ShowMessage(LegacyMessage message)
        {
            message.Show();
        }
    }
}
