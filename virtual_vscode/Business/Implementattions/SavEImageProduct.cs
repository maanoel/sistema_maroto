using System;
using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Data.Converter;
using LojaVirtual.Data.VO;
using LojaVirtual.Model;
using System.IO;

namespace LojaVirtual.Business.Implementations
{
    public class SaveImageProduct
    {
        private Product Product {get;set;}
        private String _Tipo = "jpg";
        //TODO REFATORAR QUE ESTA CLASSE TA UMA BOSTA
        public SaveImageProduct(Product product){
            this.Product = product;
        }

        public void SaveFile( ) {
           SaveFilePrincipal();
        }

        public void SaveFilePrincipal(){
            if(Product.Image!= null){
                byte[] bytes = Product.Image;
                string fileId = Product.Id.ToString();

                _Tipo = "png";
                EscreverImagem(fileId, bytes);
            }
        }

        public void SaveFile02(){
            if(Product.Image_2!= null && Product.Image_2.Length > 0){
                byte[] bytes= Product.Image_2;
                string fileId = Product.Id.ToString() + "_2";
                EscreverImagem(fileId, bytes);
            }

        }

        public void SaveFile03(){
            if(Product.Image_3 !=null&& Product.Image_3.Length > 0){
                byte[] bytes = Product.Image_3;
                string fileId = Product.Id.ToString() + "_3";
                EscreverImagem(fileId, bytes);
            }
        }

        public void SaveFile04(){
            if(Product.Image_4 != null&& Product.Image_4.Length > 0){
                byte[] bytes =  Product.Image_4;
                string fileId = Product.Id.ToString() + "_4";

                EscreverImagem(fileId, bytes);
            }

        }

        public void EscreverImagem(string fileId, byte[] bytes){
            string fileName = @"/home/vitor777/Desktop/loja_virtual/produtos_imagem/" + fileId + "." + _Tipo;

            if(!File.Exists(fileName)){
                File.WriteAllBytes(fileName, bytes);
            }
        }

        public void Save(){
            SaveFile02();
            SaveFile03();
            SaveFile04();
            SaveFilePrincipal();
    
        }

    }
}
