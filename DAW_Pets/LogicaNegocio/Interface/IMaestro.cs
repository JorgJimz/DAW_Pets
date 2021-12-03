using DAW_Pets.Models;
using DAW_Pets.Models.DataTransferObjects;
using System.Threading.Tasks;

namespace DAW_Pets.LogicaNegocio.Interface
{
    public interface IMaestro
    {
        MaestroResponse GetAll_Vacuna();
        MaestroResponse GetAll_Actividad();
        MaestroResponse GetAll_Vida();
        MaestroResponse GetAll_Especie();
        MaestroResponse GetAll_Situacion();
        MaestroResponse GetAll_Caracter();
        MaestroResponse GetAll_Clima();
        MaestroResponse GetAll_Habitat();
        MaestroResponse GetAll_Tamano();
    }
}
