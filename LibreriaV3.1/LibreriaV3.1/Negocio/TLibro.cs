using LibreriaV3._1.Comun;


namespace LibreriaV3._1.Modelo
{
    class TLibro
    {
        public string CodLibro { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Tema { get; set; }
        public string Paginas { get; set; }
        public string Precio { get; set; }
        public string Formatouno { get; set; }
        public string Formatodos { get; set; }
        public string Formatotres { get; set; }
        public string Estado { get; set; }
        public string Borrado { get; set; }

        public TLibro(string codLibro, string autor, string titulo, string tema, string paginas, string precio, string formatouno, string formatodos, string formatotres, string estado, string borrado)
        {   this.CodLibro = codLibro;
            this.Autor = autor;
            this.Titulo = titulo;
            this.Tema = tema;
            this.Paginas = paginas;
            this.Precio = precio;
            this.Formatouno = formatouno;
            this.Formatodos = formatodos;
            this.Formatotres = formatotres;
            this.Estado = estado;
            this.Borrado = borrado;
        }
        public TLibro(string autor, string titulo, string tema, string paginas, string precio, string formatouno, string formatodos, string formatotres, string estado)
        {   
            this.CodLibro =Util.GenerarCodigo(this.GetType());
            this.Autor = autor;
            this.Titulo = titulo;
            this.Tema = tema;
            this.Paginas = paginas;
            this.Precio = precio;
            this.Formatouno = formatouno;
            this.Formatodos = formatodos;
            this.Formatotres = formatotres;
            this.Estado = estado;
            this.Borrado = "0";
        }
        public TLibro() { }

        public override string ToString()
        {
            return CodLibro+": " +Titulo.ToUpper();
        }

    }

    

}
