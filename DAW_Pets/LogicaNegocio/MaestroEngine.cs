using DAW_Pets.LogicaNegocio.Interface;
using DAW_Pets.Models;
using DAW_Pets.Models.DataTransferObjects;
using DAW_Pets.Models.Helpers;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System;

namespace DAW_Pets.LogicaNegocio
{
    public class MaestroEngine : IMaestro
    {
        private readonly IWebServiceEngine _ws;
        private readonly IConfiguration _config;

        public MaestroEngine(IWebServiceEngine _ws, IConfiguration _config)
        {
            this._config = _config;
            this._ws = _ws;
        }


        public MaestroResponse GetAll_Actividad()
        {
            MaestroResponse response = new MaestroResponse();
            Header header = new Header();
            try
            {
                response.Lista = _ws.GetAll_Service<Maestro>("Servicios:Maestro").Result.Listado.Where(x => x.Grupo.Equals(Constantes.ActividadFisica)).ToList();
                header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                header.DescRetorno = string.Empty;
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }

        public MaestroResponse GetAll_Vacuna()
        {
            MaestroResponse response = new MaestroResponse();
            Header header = new Header();
            try
            {
                response.Lista = _ws.GetAll_Service<Maestro>("Servicios:Maestro").Result.Listado.Where(x => x.Grupo.Equals(Constantes.Vacuna)).ToList();
                header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                header.DescRetorno = string.Empty;
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }

        public MaestroResponse GetAll_Vida()
        {
            MaestroResponse response = new MaestroResponse();
            Header header = new Header();
            try
            {
                response.Lista = _ws.GetAll_Service<Maestro>("Servicios:Maestro").Result.Listado.Where(x => x.Grupo.Equals(Constantes.EsperanzaVida)).ToList();
                header.CodigoRetorno = HeaderEnum.Correcto.ToString();  
                header.DescRetorno = string.Empty;
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }

        public MaestroResponse GetAll_Especie()
        {
            MaestroResponse response = new MaestroResponse();
            Header header = new Header();
            try
            {
                response.Lista = _ws.GetAll_Service<Maestro>("Servicios:Maestro").Result.Listado.Where(x => x.Grupo.Equals(Constantes.Especie)).ToList();
                header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                header.DescRetorno = string.Empty;
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }

        public MaestroResponse GetAll_Situacion()
        {
            MaestroResponse response = new MaestroResponse();
            Header header = new Header();
            try
            {
                response.Lista = _ws.GetAll_Service<Maestro>("Servicios:Maestro").Result.Listado.Where(x => x.Grupo.Equals(Constantes.Situacion)).ToList();
                header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                header.DescRetorno = string.Empty;
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }

        public MaestroResponse GetAll_Caracter()
        {
            MaestroResponse response = new MaestroResponse();
            Header header = new Header();
            try
            {
                response.Lista = _ws.GetAll_Service<Maestro>("Servicios:Maestro").Result.Listado.Where(x => x.Grupo.Equals(Constantes.Caracter)).ToList();
                header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                header.DescRetorno = string.Empty;
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }

        public MaestroResponse GetAll_Clima()
        {
            MaestroResponse response = new MaestroResponse();
            Header header = new Header();
            try
            {
                response.Lista = _ws.GetAll_Service<Maestro>("Servicios:Maestro").Result.Listado.Where(x => x.Grupo.Equals(Constantes.Clima)).ToList();
                header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                header.DescRetorno = string.Empty;
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }

        public MaestroResponse GetAll_Habitat()
        {
            MaestroResponse response = new MaestroResponse();
            Header header = new Header();
            try
            {
                response.Lista = _ws.GetAll_Service<Maestro>("Servicios:Maestro").Result.Listado.Where(x => x.Grupo.Equals(Constantes.Habitat)).ToList();
                header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                header.DescRetorno = string.Empty;
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }

        public MaestroResponse GetAll_Tamano()
        {
            MaestroResponse response = new MaestroResponse();
            Header header = new Header();
            try
            {
                response.Lista = _ws.GetAll_Service<Maestro>("Servicios:Maestro").Result.Listado.Where(x => x.Grupo.Equals(Constantes.Tamano)).ToList();
                header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                header.DescRetorno = string.Empty;
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }

        public MaestroResponse GetAll_Estado()
        {
            MaestroResponse response = new MaestroResponse();
            Header header = new Header();
            try
            {
                response.Lista = _ws.GetAll_Service<Maestro>("Servicios:Maestro").Result.Listado.Where(x => x.Grupo.Equals(Constantes.EstadoSolicitud)).ToList();
                header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                header.DescRetorno = string.Empty;
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }
    }
}
