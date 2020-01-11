using System;
using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Data.Converter;
using LojaVirtual.Data.VO;
using LojaVirtual.Model;

namespace LojaVirtual.Data.Converters
{
    public class ProductConverter : IParser<ProductVO, Product>, IParser<Product, ProductVO>
    {
        public Product Parse(ProductVO origin, Product dest){
            
            if (origin == null) return dest;

            if(origin.Id != null) dest.Id = origin.Id;
            if(origin.Categoria != null)dest.Categoria = origin.Categoria;
            if(origin.Cor != null)dest.Cor = origin.Cor;
            if(origin.Descricao != null)dest.Descricao = origin.Descricao;
            if(origin.Medida != null)dest.Medida = origin.Medida;
            if(origin.Peso > 0)dest.Peso = origin.Peso;
            if(origin.Quantidade > 0)dest.Quantidade = origin.Quantidade;
            if(origin.Valor > 0 )dest.Valor = origin.Valor;
            
            if(origin.ImageBas64 != null)  dest.Image = Convert.FromBase64String(origin.ImageBas64);
            if(origin.ImageBas64_2 != null)  dest.Image_2 = Convert.FromBase64String(origin.ImageBas64_2);
            if(origin.ImageBas64_3 != null)  dest.Image_3 = Convert.FromBase64String(origin.ImageBas64_3);
            if(origin.ImageBas64_4 != null)  dest.Image_4 = Convert.FromBase64String(origin.ImageBas64_4);
            if(origin.ImageBas64_5 != null)  dest.Image_5 = Convert.FromBase64String(origin.ImageBas64_5);

            return dest;
        }

        public Product Parse(ProductVO origin)
        {
         
            if (origin == null) return new Product();

           Product p =  new Product()
            {
                Id = origin.Id,
                Categoria = origin.Categoria,
                Cor = origin.Cor,
                Descricao = origin.Descricao,
                Medida = origin.Medida,
                Peso = origin.Peso,
                Quantidade = origin.Quantidade,
                Valor = origin.Valor
            };

            if(origin.ImageBas64 != null)  p.Image = Convert.FromBase64String(origin.ImageBas64);
            if(origin.ImageBas64_2 != null)  p.Image_2 = Convert.FromBase64String(origin.ImageBas64_2);
            if(origin.ImageBas64_3 != null)  p.Image_3 = Convert.FromBase64String(origin.ImageBas64_3);
            if(origin.ImageBas64_4 != null)  p.Image_4 = Convert.FromBase64String(origin.ImageBas64_4);
            if(origin.ImageBas64_5 != null)  p.Image_5 = Convert.FromBase64String(origin.ImageBas64_5);

            return p;

        }

        public ProductVO Parse(Product origin)
        {
            if (origin == null) return new ProductVO();

            ProductVO p = new ProductVO()
            {
                Id = origin.Id,
                Categoria = origin.Categoria,
                Cor = origin.Cor,
                Descricao = origin.Descricao,
                Medida = origin.Medida,
                Peso = origin.Peso,
                Quantidade = origin.Quantidade,
                Valor = origin.Valor
            };
            
            if(origin.Image != null ) p.ImageBas64 = Convert.ToBase64String(origin.Image);
            if(origin.Image_2 != null ) p.ImageBas64_2 = Convert.ToBase64String(origin.Image_2);
            if(origin.Image_3 != null ) p.ImageBas64_3 = Convert.ToBase64String(origin.Image_3);
            if(origin.Image_4!= null ) p.ImageBas64_4 = Convert.ToBase64String(origin.Image_4);
            if(origin.Image_5 != null ) p.ImageBas64_5 = Convert.ToBase64String(origin.Image_5);

            return p;

        }

        public List<Product> ParseList(List<ProductVO> origin)
        {
            if (origin == null) return new List<Product>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<ProductVO> ParseList(List<Product> origin)
        {
            if (origin == null) return new List<ProductVO>();
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
