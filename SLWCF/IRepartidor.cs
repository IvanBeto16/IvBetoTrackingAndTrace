using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IRepartidor" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IRepartidor
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        bool Add(ML.Repartidor repartidor);

        [OperationContract]
        bool Update(ML.Repartidor repartidor);

        [OperationContract]
        bool Delete(int idRepartidor);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Repartidor))]
        List<ML.Repartidor> GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Repartidor))]
        ML.Repartidor GetById(int idRepartidor);

    }
}
