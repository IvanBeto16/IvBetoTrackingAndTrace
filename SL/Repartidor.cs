using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Repartidor" en el código y en el archivo de configuración a la vez.
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
            ML.Repartidor repartidor = BL.Repartidor.GetById(idRepartidor);
            return repartidor;
        }
    }
}
