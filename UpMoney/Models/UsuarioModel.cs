using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpMoney.Util;
using System.ComponentModel.DataAnnotations;
using System.Data;



namespace UpMoney.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Informe seu Nome!")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Informe seu Email!")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Informe sua password!")]
        public String Senha { get; set; }

        //string Email = "leo@gmail.com";
        //string password = "1234";

      

        public bool ValidarLogin()
        {
            DataTable dt = null;

            if (Email != null && Email != "" && Senha != null && Senha != "")
            {
                string sql = $"SELECT IDCLIENTE,NOME FROM CLIENTE WHERE EMAIL = '{Email}' AND SENHA = '{Senha}'";
                DAL OBJDAL = new DAL();
                dt = OBJDAL.RetDataTable(sql);
            }

            if (dt != null)
            {

                if (dt.Rows.Count == 1)
                {
                    Id = int.Parse(dt.Rows[0]["IDCLIENTE"].ToString());
                    Nome = dt.Rows[0]["NOME"].ToString();                    
                    return true;
                }

            }

            return false;
        }

        public bool RegistrarUsuario()
        {


            if (Nome != null && Nome != "" && Email != null && Email != "" && Senha != null && Senha != "")
            {
                try
                {
                    string sql = $"INSERT INTO CLIENTE (NOME,EMAIL,SENHA) VALUE('{Nome}', '{Email}','{Senha})";
                    DAL objDAL = new DAL();
                    objDAL.ExecutaComandoSQL(sql);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
                return false; 
                
                

            //string dataNascimento = DateTime.Parse(Data_Nascimento).ToString("yyyy/MM/dd");
 


        }
    }

}

