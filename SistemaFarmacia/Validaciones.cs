using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SistemaFarmacia
{
    public class Validaciones
    {
        public static void SoloLetras(KeyPressEventArgs V)
        {
            if (Char.IsLetter(V.KeyChar))
            {
                V.Handled = false;
            }
            else if (Char.IsSeparator(V.KeyChar))
            {
                V.Handled = false;
            }
            else if (Char.IsControl(V.KeyChar))
            {
                V.Handled = false;
            }
            else
            {
                V.Handled = true;
                //MessageBox.Show("Solo Letras");
            }
        }

        public static void SoloNumeros(KeyPressEventArgs V)
        {
            if (Char.IsDigit(V.KeyChar))
            {
                V.Handled = false;
            }
            else if (Char.IsSeparator(V.KeyChar))
            {
                V.Handled = false;
            }
            else if (Char.IsControl(V.KeyChar))
            {
                V.Handled = false;
            }
            else 
            {
                V.Handled = true;
                //MessageBox.Show("Solo numeros");
            }
        }

        public static void NumerosDecimal(KeyPressEventArgs V)
        {
            if (Char.IsDigit(V.KeyChar))
            {
                V.Handled = false;
            }
            else if (Char.IsSeparator(V.KeyChar))
            {
                V.Handled = false;
            }
            else if (Char.IsControl(V.KeyChar))
            {
                V.Handled = false;
            }
            else if (V.KeyChar.ToString().Equals("."))
            {
                V.Handled = false;
            }
            else
            {
                V.Handled = true;
            }
        }

        public static void validarTamanioCedula(KeyPressEventArgs e, TextBox texto, int tamLimite)
        {
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                if (texto.Text.Length >= tamLimite)
                    e.Handled = true;
                else
                {
                    //Para obligar a que sólo se introduzcan números 
                    if (Char.IsDigit(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        //el resto de teclas pulsadas se desactivan 
                        e.Handled = true;
                    }
                }
            }
        }

        public static void validarTamanioTelefonos(KeyPressEventArgs e, TextBox texto, int tamLimite)
        {
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //que no pase del tamño limite
                if (texto.Text.Length >= tamLimite)
                    e.Handled = true;
                else
                {
                    //Para obligar a que sólo se introduzcan números y -
                    if (Char.IsDigit(e.KeyChar) || e.KeyChar == '-')
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        //el resto de teclas pulsadas se desactivan 
                        e.Handled = true;
                    }
                }
            }
        }

        public static void validarTamanioString(KeyPressEventArgs e, TextBox texto, int tamLimite)
        {
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                if (texto.Text.Length >= tamLimite)
                    e.Handled = true;
                else
                    e.Handled = false;
            }
        }

        public static void validarDecimalCelda(KeyPressEventArgs e, string texto)
        {

            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
            {
                if (texto.Contains(",") && e.KeyChar.ToString() == ",")
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        public static void validarDecimal(KeyPressEventArgs e, TextBox texto)
        {

            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
            {
                if (texto.Text.Contains(",") && e.KeyChar.ToString() == ",")
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        public static bool esDecimal(String dec)
        {
            try
            {
                if (decimal.Parse(dec) >= 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void validarEntero(KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        public static bool esCedulaValida(String cedula)
        {
            if (cedula.Length == 13 && cedula.Substring(10, 3) == "001")
                cedula = cedula.Substring(0, 10);

            bool mistmatch = false;
            for (int i = 0; i < cedula.Length; i++)
            {
                if (i > 0 && cedula[i] != cedula[i - 1])
                    mistmatch = true;
            }
            if (mistmatch == false)
                return mistmatch;

            //verifica que tenga 10 dígitos 
            if (!(cedula.Length == 10))
            {
                return false;
            }
            //verifica que los dos primeros dígitos correspondan a un valor entre 1 y NUMERO_DE_PROVINCIAS
            int prov = int.Parse(cedula.Substring(0, 2));
            if (!((prov > 0) && (prov <= 24)))
            {
                return false;
            }
            //verifica que el último dígito de la cédula sea válido
            int[] d = new int[10];
            //Asignamos el string a un array
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(cedula.Substring(i, 1) + "");
            }
            int imp = 0;
            int par = 0;
            //sumamos los duplos de posición impar
            for (int i = 0; i < d.Length; i += 2)
            {
                d[i] = ((d[i] * 2) > 9) ? ((d[i] * 2) - 9) : (d[i] * 2);
                imp += d[i];
            }
            //sumamos los digitos de posición par
            for (int i = 1; i < (d.Length - 1); i += 2)
            {
                par += d[i];
            }
            //Sumamos los dos resultados
            int suma = imp + par;
            //Restamos de la decena superior
            int d10 = int.Parse(Convert.ToString(suma + 10).Substring(0, 1) + "0") - suma;
            //Si es diez el décimo dígito es cero        
            d10 = (d10 == 10) ? 0 : d10;
            //si el décimo dígito calculado es igual al digitado la cédula es correcta
            return d10 == d[9];
        }
    }
}
