using AutoMapper;
using SEC.ENTITI;
using SEC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEC.MVC.AutoMapperConfig
{
    public class MappingProfile: Profile
    {
      
        
            public MappingProfile()
            {
                CreateMap<UsuariosModel, Usuarios>();
                CreateMap<Usuarios, UsuariosModel>();

            CreateMap<PreguntasModel, Preguntas>();
            CreateMap<Preguntas, PreguntasModel>();

            CreateMap<TecnologiasModel, Tecnologias>();
            CreateMap<Tecnologias, TecnologiasModel>();

            CreateMap<NivelesModel, Niveles>();
            CreateMap<Niveles, NivelesModel>();

        }
        

    }
}