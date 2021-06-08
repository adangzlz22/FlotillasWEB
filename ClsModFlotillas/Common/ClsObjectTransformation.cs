using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModHarodoor.Common
{
    public class ClsObjectTransformation
    {

        private string _MsgError = "";

        public string MsgError
        {
            get { return _MsgError; }
            set { _MsgError = value; }
        }

        public static string TypeArrayToString(Type[] arrType)
        {
            string strCadena = "";
            if (arrType.Count() > 0)
            {
                foreach (Type objType in arrType)
                {
                    strCadena += objType.AssemblyQualifiedName + "\n";
                }
            }
            return strCadena;
        }

        public static Type[] StringToTypeArray(string strCadena)
        {
            List<Type> lstType = new List<Type>();
            if (strCadena != null && strCadena != "")
            {
                //Primero tranformo a un array de string con el delimitador \n
                string[] strArray = strCadena.Split('\n');

                foreach (string strItem in strArray)
                {
                    lstType.Add(Type.GetType(strItem));
                }

                lstType.RemoveAt(lstType.Count - 1);
            }

            return lstType.ToArray();
        }




        public MemoryStream SerializeObject<T>(T objSerialize)
        {
            MemoryStream MemStrResultado = null;
            try
            {
                ClsXmlConvert objXmlConvert = new ClsXmlConvert();
                MemStrResultado = objXmlConvert.SerializeObject(objSerialize);
                _MsgError = objXmlConvert.MsgError;


            }
            catch (Exception ex)
            {
                _MsgError = ex.Message;
            }

            return MemStrResultado;
        }
        public MemoryStream SerializeObject<T>(List<T> lst)
        {
            MemoryStream MemStrResultado = null;
            try
            {
                ClsXmlConvert objXmlConvert = new ClsXmlConvert();
                MemStrResultado = objXmlConvert.SerializeObject(lst);
                _MsgError = objXmlConvert.MsgError;
            }
            catch (Exception ex)
            {
                _MsgError = ex.Message;
            }

            return MemStrResultado;
        }


        ///// <summary>
        ///// Serializa el objeto enviado y devuelve como string
        ///// </summary>
        ///// <typeparam name="T">Tipo del modelo</typeparam>
        ///// <param name="objSerialize">objeto a serializar</param>
        ///// <param name="FormatoRespuestaWCF">Tipo de formato</param>
        ///// <returns>Regresa una cadena con el modelo </returns>
        //public static string SerializeObjectToString<T>(T objSerialize)
        //{
        //    return ClsXmlConvert.SerializeObjectToString(objSerialize);

        //}

        /// <summary>
        /// Serializa el objeto enviado y devuelve como string
        /// </summary>
        /// <typeparam name="T">Tipo del modelo</typeparam>
        /// <param name="objSerialize">objeto a serializar</param>
        /// <param name="FormatoRespuestaWCF">Tipo de formato</param>
        /// <returns>Regresa una cadena con el modelo </returns>
        public static string SerializeObjectToString<T>(T objSerialize, FormatoRespuesta FormatoRespuestaWCF)
        {
            string strResultado = "";

            switch (FormatoRespuestaWCF)
            {
                case FormatoRespuesta.XML:
                    strResultado = ClsXmlConvert.SerializeObjectToString(objSerialize);
                    break;
                case FormatoRespuesta.JSON:

                    strResultado = Newtonsoft.Json.JsonConvert.SerializeObject(objSerialize);
                    break;
            }

            return strResultado;

        }


        /// <summary>
        /// Serializa el objeto enviado y devuelve como string
        /// </summary>
        /// <typeparam name="T">Tipo del modelo</typeparam>
        /// <param name="objSerialize">objeto a serializar</param>
        /// <param name="FormatoRespuestaWCF">Tipo de formato</param>
        /// <returns>Regresa una cadena con el modelo </returns>
        public static string SerializeObjectToString<T>(List<T> objSerialize, FormatoRespuesta FormatoRespuestaWCF)
        {
            string strResultado = "";
            if (objSerialize != null && objSerialize.Count > 0)
            {
                switch (FormatoRespuestaWCF)
                {
                    case FormatoRespuesta.XML:
                        strResultado = ClsXmlConvert.SerializeObjectToString(objSerialize);
                        break;
                    case FormatoRespuesta.JSON:
                        strResultado = Newtonsoft.Json.JsonConvert.SerializeObject(objSerialize);
                        break;
                }
            }

            return strResultado;

        }

        /// <summary>
        /// Deserializa el objeto enviado
        /// </summary> 
        /// <typeparam name="T">Tipo</typeparam>
        /// <param name="strModelo">Modelo a serializar</param>
        /// <param name="FormatoRespuestaWCF">Tipo de formato</param>
        /// <returns>regresa modelo de respuesta</returns>
        public static T Deserialize<T>(string strModelo, FormatoRespuesta FormatoRespuestaWCF)
        {
            T objBasDes = default(T);
            switch (FormatoRespuestaWCF)
            {
                case FormatoRespuesta.XML:
                    objBasDes = ClsXmlConvert.DeserializeObject<T>(strModelo);
                    break;
                case FormatoRespuesta.JSON:
                    objBasDes = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(strModelo);
                    break;
            }

            return objBasDes;
        }


    }
}
