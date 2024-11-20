//using System;
//using System.Buffers.Text;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Domain.Dtos.NsfwSpyP;
//using Domain.Interfaces.Services.NsfwSpy;
//using NsfwSpyNS;

//namespace Service.Services
//{
//    public class INsfwSpyPServicoService : INsfwSpyPServico
//    {
//        private NsfwSpy _nsfwSpy;


//        public INsfwSpyPServicoService( NsfwSpy nsfwSpy) 
//        {      
//            _nsfwSpy = nsfwSpy;
//        }
//        public async Task<NsfwSpyPDto> GetBase64(String imagem)
//        {

//            byte[] bytes = System.Convert.FromBase64String(imagem);
//            var result = _nsfwSpy.ClassifyImage(bytes);

//            return null;
//        }
//    }
//}
