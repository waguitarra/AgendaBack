using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public class ImagensFSeeds
    {
        public static void ImagensP(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImagensFEntity>().HasData(

		  //Morango -------------------------------------------------------------------
			new ImagensFEntity
			{
				Id = new Guid("2c535f85-e97b-49b9-915a-2fbf0f4b91d3"),
				UrlImagens = "https://s2.glbimg.com/V7gaBnXPpaJity5k7_s5xVjvpCw=/512x320/smart/e.glbimg.com/og/ed/f/original/2017/09/14/selvvva_2.jpg",
				FornecedorProdutosId = new Guid("4851fe4c-7b26-441e-b090-f03d930e705c"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("86ef05a5-38b7-431c-90ae-559b98b10de3"),
				UrlImagens = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWjP12VOHFiN39VHmAeWKHGj5XJfKYlxeHMZu-HGDUl5ErALkKSfDsxt4q99qHx-Abqfc&usqp=CAU",
				FornecedorProdutosId = new Guid("4851fe4c-7b26-441e-b090-f03d930e705c"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("c3ca37c5-4ef0-4c89-a13e-003a6ba53276"),
				UrlImagens = "https://i.pinimg.com/originals/fb/04/dd/fb04ddc95720a2b2afa205bdd6d2ec01.jpg",
				FornecedorProdutosId = new Guid("4851fe4c-7b26-441e-b090-f03d930e705c"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("2f112b28-2c34-4bb0-a789-f7feb1bdd901"),
				UrlImagens = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWjP12VOHFiN39VHmAeWKHGj5XJfKYlxeHMZu-HGDUl5ErALkKSfDsxt4q99qHx-Abqfc&usqp=CAU",
				FornecedorProdutosId = new Guid("4851fe4c-7b26-441e-b090-f03d930e705c"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("81d0e24c-6abd-4335-8980-06cc4436ca32"),
				UrlImagens = "https://avidanocentro.com.br/wp-content/uploads/2019/03/selvvva-3.jpg",
				FornecedorProdutosId = new Guid("4851fe4c-7b26-441e-b090-f03d930e705c"),
				CreateAt = DateTime.Now,
			},

			new ImagensFEntity
			{
				Id = new Guid("cbbc0b59-4ac6-4572-a80f-d720ac4b29bd"),
				UrlImagens = "https://lh3.googleusercontent.com/proxy/yriFAqW-IojltHn9PtKwCzeVGxqWeIfxgW9iKgldnTEZUTec3FmqnC9tUN5Xy5Bhv7kqEodEXg9ikC8_ufydYWPgn8AO5dRNSPW80gV4",
				FornecedorProdutosId = new Guid("dd41a0f8-4bbc-4668-9ca3-0788defedfa0"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("3123321f-2405-4f04-a64e-0b4f443a192b"),
				UrlImagens = "https://lh3.googleusercontent.com/proxy/9fdDr_cIaPrBbRvRbKpMMtIiYArhky6tSPIBU-QXDH76sJVKZa1QYkODcN6pqL3e_t5f6ZQf61le_f6tFOwv2gwFpmvrZ8IPdH6h",
				FornecedorProdutosId = new Guid("dd41a0f8-4bbc-4668-9ca3-0788defedfa0"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("e78a82ed-823b-4421-899e-2b2fd1fa93d6"),
				UrlImagens = "https://i.ytimg.com/vi/fsgs25UEvMc/maxresdefault.jpg",
				FornecedorProdutosId = new Guid("dd41a0f8-4bbc-4668-9ca3-0788defedfa0"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("a84321bb-5928-448d-b2db-83ae5c27687c"),
				UrlImagens = "https://i.pinimg.com/originals/86/75/e9/8675e9110568bad3d8f7130f0b9ba695.jpg",
				FornecedorProdutosId = new Guid("dd41a0f8-4bbc-4668-9ca3-0788defedfa0"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("979f78a9-69f6-48ad-bb09-bae6480ccbfa"),
				UrlImagens = "https://imagens-revista.vivadecora.com.br/uploads/2018/12/Tipos-de-plantas-ornamentais-que-valorizam-o-espa%C3%A7o.jpg",
				FornecedorProdutosId = new Guid("dd41a0f8-4bbc-4668-9ca3-0788defedfa0"),
				CreateAt = DateTime.Now,
			},

			new ImagensFEntity
			{
				Id = new Guid("c1af2177-7044-40b3-82e3-cb52a717e13d"),
				UrlImagens = "https://www.tuacasa.com.br/wp-content/uploads/2016/06/rafia-730x548.jpg",
				FornecedorProdutosId = new Guid("c4406ef2-2e69-4530-828e-3fedd6dd66e7"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("a38748a1-dd40-4ad1-a126-6989d407eb13"),
				UrlImagens = "http://www.wdicas.com/wp-content/uploads/2011/03/plantas-ornamentais-para-jardim-palmeiras.jpg",
				FornecedorProdutosId = new Guid("c4406ef2-2e69-4530-828e-3fedd6dd66e7"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("9c09d5fd-021f-403f-a78d-45fabd44d53b"),
				UrlImagens = "https://www.noticiasdejardim.com/wp-content/uploads/2020/07/cuidados-com-a-planta-livistona-chinensis-ou-palmeira-chinesa-778x470.jpg",
				FornecedorProdutosId = new Guid("c4406ef2-2e69-4530-828e-3fedd6dd66e7"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("34da7957-ca46-4f65-aec5-23b345f17175"),
				UrlImagens = "https://i.pinimg.com/originals/77/67/01/776701191693a96168b2d33f214140f4.png",
				FornecedorProdutosId = new Guid("c4406ef2-2e69-4530-828e-3fedd6dd66e7"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("4ec68927-6535-4451-bfd0-400be82c838f"),
				UrlImagens = "https://www.france-voyage.com/visuals/photos/jardim-plantas-35474_w600.webp",
				FornecedorProdutosId = new Guid("c4406ef2-2e69-4530-828e-3fedd6dd66e7"),
				CreateAt = DateTime.Now,
			},

			new ImagensFEntity
			{
				Id = new Guid("dd9cea5d-e16d-48b4-8cdc-40102442ce9a"),
				UrlImagens = "https://i.pinimg.com/originals/ab/e5/f8/abe5f8832adbbdb3b8f1f5713ef4a342.jpg",
				FornecedorProdutosId = new Guid("d36684ae-77b3-4885-b863-12f392fd5ae3"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("bbe57a1c-e479-4f68-854c-f5f1673d12e8"),
				UrlImagens = "https://i.pinimg.com/736x/fc/c8/46/fcc846be7810c245d33dcb2ec957197c.jpg",
				FornecedorProdutosId = new Guid("d36684ae-77b3-4885-b863-12f392fd5ae3"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("d2ca66d4-fed3-4c6e-8ab5-b968dabbcb29"),
				UrlImagens = "https://images.arquidicas.com.br/wp-content/uploads/2015/09/24200607/plantas-para-jardim-de-inverno.jpg",
				FornecedorProdutosId = new Guid("d36684ae-77b3-4885-b863-12f392fd5ae3"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("26e06286-444f-45cc-8327-caa0daf2852f"),
				UrlImagens = "https://casa.abril.com.br/wp-content/uploads/2016/12/aec288-48-meujardim01.jpeg?quality=95&strip=info&w=506",
				FornecedorProdutosId = new Guid("d36684ae-77b3-4885-b863-12f392fd5ae3"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("baf04008-1b27-41c6-a698-0f43de93bc7a"),
				UrlImagens = "https://casa.abril.com.br/wp-content/uploads/2016/12/ac-0265-32-paisag1.jpeg?quality=70&strip=all",
				FornecedorProdutosId = new Guid("d36684ae-77b3-4885-b863-12f392fd5ae3"),
				CreateAt = DateTime.Now,
			},

			new ImagensFEntity
			{
				Id = new Guid("15eae589-d7d5-47cc-aca6-016fe86486f8"),
				UrlImagens = "https://digitalphoto.pl/foto_galeria/2506_2007-0270.JPG",
				FornecedorProdutosId = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("60d340fb-66bb-4101-a6d7-0f4343016c9c"),
				UrlImagens = "https://decorandocasas.com.br/wp-content/uploads/2014/10/plantas-grandes-altas-jardim-3.jpg",
				FornecedorProdutosId = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("0ace245c-1643-4031-9a58-78ba3e28e667"),
				UrlImagens = "https://decorandocasas.com.br/wp-content/uploads/2014/10/plantas-grandes-altas-jardim.jpg",
				FornecedorProdutosId = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("1bb81178-1826-4bc6-9661-92e43ec6c94e"),
				UrlImagens = "https://lh3.googleusercontent.com/proxy/LPf4F9jLwsJoNUdW1heqnPtsJzOGSzfDl9NKny2KyH1hUq11bpKpjTBk-UVr9CLt-tJNXPCuHngZ9eONovihmNqeohHzcZXgy6m_iZEjNneGMvxuS93FQ08",
				FornecedorProdutosId = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("05d56096-b43e-4f58-b36c-320932c058e5"),
				UrlImagens = "https://i.pinimg.com/originals/e4/e0/78/e4e078ff8729d94ea6cd6d35ecf884c4.jpg",
				FornecedorProdutosId = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("c05125dd-dacc-4606-9bbc-1bcf345b01fe"),
				UrlImagens = "https://decorandocasas.com.br/wp-content/uploads/2014/10/plantas-grandes-altas-jardim-4.jpg",
				FornecedorProdutosId = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("ca085f9b-0e04-4a81-91f1-224ac4e4bb43"),
				UrlImagens = "https://p2.trrsf.com/image/fget/cf/940/0/images.terra.com/2018/07/04/plantas-ornamentais-para-jardim-externo.jpg",
				FornecedorProdutosId = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("0055b677-011d-4265-8c35-70cb43fa8d3b"),
				UrlImagens = "https://i.pinimg.com/236x/cc/d1/3f/ccd13f43f3fbe3748073f80ed689f6a2--interior-garden-garden-plants.jpg",
				FornecedorProdutosId = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("eb27862d-ff1c-4a9f-8bc2-a9bf25f8599e"),
				UrlImagens = "https://www.coelhosjardinagens.com.br/wp-content/uploads/2020/06/yuca-verde.jpg",
				FornecedorProdutosId = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
				CreateAt = DateTime.Now,
			},
			new ImagensFEntity
			{
				Id = new Guid("a28e4981-98cd-4c19-ba73-48dbdd4ed7fd"),
				UrlImagens = "https://spacegarden.es/219-large_default/Yucca-elephantipes.jpg",
				FornecedorProdutosId = new Guid("5036d248-1bc8-493f-8649-163fef9e4b18"),
				CreateAt = DateTime.Now,
			}

		
		  );
        }
    }
}


