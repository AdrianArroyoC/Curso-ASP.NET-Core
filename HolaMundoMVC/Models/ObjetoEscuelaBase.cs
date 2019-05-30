using System;

namespace HolaMundoMVC.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }
        
        public virtual string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            
        }
    }
}