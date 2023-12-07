using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Repartidor" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Repartidor.svc o Repartidor.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Repartidor : IRepartidor
    {
        public void DoWork()
        {
        }

        public bool Add(ML.Repartidor repartidor)
        {
            bool correct = BL.Repartidor.Add(repartidor);
            return correct;
        }

        public bool Update(ML.Repartidor repartidor)
        {
            bool correct = BL.Repartidor.Update(repartidor);
            return correct;
        }

        public bool Delete(int idRepartidor)
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            repartidor.IdRepartidor = idRepartidor;
            bool correct = BL.Repartidor.Delete(repartidor);
            return correct;
        }

        public List<ML.Repartidor> GetAll()
        {
            List<ML.Repartidor> Objects = BL.Repartidor.GetAll();
            return Objects;
        }

        public ML.Repartidor GetById(int idRepartidor)
        {
            ML.Repartidor result = BL.Repartidor.GetById(idRepartidor);
            return result;
        }
    }
}
