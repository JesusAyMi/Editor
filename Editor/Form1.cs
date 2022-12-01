using System.Diagnostics;
using System.Drawing.Printing;
using static System.Windows.Forms.DataFormats;

namespace Editor
{
    public partial class fmEditor : Form
    {

        string[] linea; // V�ctor para contener las l�neas
        int totalLineasImpresas; // Controla l�neas impresas

        private void fmEditor_Resize(object sender, EventArgs e)
        {
            tamanyosestado();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void stEstadoEditor_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public fmEditor()
        {
            InitializeComponent();
            Application.Idle += AplicacionOciosa;
        }

        private void AplicacionOciosa(object sender, EventArgs e)
        {
            // Extraemos n�mero de l�nea y columna de la posici�n actual del
            // cursor en el editor
            int linea = rtbEditor.GetLineFromCharIndex(rtbEditor.SelectionStart);
            int columna = rtbEditor.SelectionStart -
            rtbEditor.GetFirstCharIndexOfCurrentLine();
            // Los Mostramos en el statusLabel 2 de la barra de estado
            // usando la matriz �tem que forman
            stEstadoEditor.Items[1].Text = "L�n." + Convert.ToString(linea + 1) +
            " Col." + Convert.ToString(columna);
            stEstadoEditor.Items[2].Text = "Car. " + //Posici�n absoluta del cursor
            Convert.ToString(rtbEditor.SelectionStart);
            // Asignamos valor (true/false) a variable en funci�n de si hay
            // selecci�n de texto
            bool HaySeleccion = rtbEditor.SelectionLength > 0;
            if (HaySeleccion) // Mostramos mensaje explicativo en barra de estado.
            { // en el primer �tem
                stEstadoEditor.Items[0].Text = "Hay Texto seleccionado";
            }
            // habilitamos botones o no seg�n se dan las condiciones
            tsbCopiar.Enabled = HaySeleccion; //Habilitados si hay
            tsbCortar.Enabled = HaySeleccion; // texto seleccionado
            tsbDeshacer.Enabled = rtbEditor.CanUndo; // Si hay algo para deshacer
            tsbRehacer.Enabled = rtbEditor.CanRedo; // o rehacer
            tsbPegar.Enabled = Clipboard.ContainsText();//Si hay texto en el
                                                        // portapapeles
                                                        // Tambi�n Habilitamos o no los correspondientes �tems de men�
            itBorrar.Enabled = HaySeleccion;
            itPegar.Enabled = tsbPegar.Enabled;
            itCopiar.Enabled = tsbCopiar.Enabled;
            itCortar.Enabled = tsbCortar.Enabled;
            itDeshacer.Enabled = tsbDeshacer.Enabled;
            itRehacer.Enabled = tsbRehacer.Enabled;
        }

        private void tamanyosestado()
        { //Asignamos width a trav�s de la matriz �tem que forman los StatusLabel
            stEstadoEditor.Items[0].Width = Width - 350;
            stEstadoEditor.Items[1].Width = 100;
            stEstadoEditor.Items[2].Width = 60;
            stEstadoEditor.Items[3].Width = 70;
            stEstadoEditor.Items[4].Width = 90;
        }

        private void fmEditor_Load(object sender, EventArgs e)
        {
            tamanyosestado();
            foreach (FontFamily misfuentes in FontFamily.Families)
            { // Cargamos fuentes del sistema en ComboBox
                cbFuentes.Items.Add(misfuentes.Name);
            }

            // Elegimos una fuente por defecto
            cbFuentes.Text = "Microsoft Sans Serif";
            // Ponemos tama�o elegido
            cbTamanyo.Text = "8";

            Text = "Documento1";//Asignamos nombre por defecto al archivo,
                                //que se usar� al guardar y lo mostramos en la barra de t�tulo
            rtbEditor.ClearUndo(); // limpiamos buffer deshacer
            itQuitarFormatos.PerformClick(); //Invocamos este evento click
                                             // que asigna valores por defecto iniciales
            rtbEditor.Modified = false; //Modificaciones en editor a false
                                        // significa que no hay cambios y a true que se han producido cambios
            rtbEditor.Focus(); //Enviamos foco al Richtextbox
        }
        private void itQuitarFormatos_Click(object sender, EventArgs e)
        {
            itIzq.Checked = true;
            tsbAlineaIzq.Checked = true;
            tsbNegrita.Checked = false;
            tsbCursiva.Checked = false;
            tsbSubrayado.Checked = false;
            tsbTachado.Checked = false;
            tsbCopiarFormatos.Checked = false;
            // Asignamos a los controles y al RichTextBox los valores
            // iniciales elegidos para el tipo de fuente
            FontStyle estilo = new FontStyle();
            rtbEditor.SelectionFont = new Font("Arial", 10, estilo);
            rtbEditor.SelectionColor = Color.Black;
            rtbEditor.SelectionAlignment = HorizontalAlignment.Left;
            cbFuentes.SelectedIndex = cbFuentes.Items.IndexOf("Arial");
            cbTamanyo.Text = "10";
            //Lo mismo para el resto de configuraciones del editor
            rtbEditor.BackColor = Color.White;
            rtbEditor.SelectionRightIndent = 0;
            rtbEditor.SelectionIndent = 0;
            rtbEditor.SelectionBullet = false;
            itVi�etas.Checked = false;
        }
        private void timeEditor_Tick(object sender, EventArgs e)
        { //Obtenemos fecha/hora actual y
            DateTime fecha = DateTime.Now; // la mostramos formateada
            stEstadoEditor.Items[3].Text = fecha.ToString("dd/MM/yyyy");
            stEstadoEditor.Items[4].Text = fecha.ToString("HH:mm:ss");
        }

        private void tsbNegrita_Click(object sender, EventArgs e)
        {
            FontStyle negrita = new FontStyle();//Variables para establecer el estilo
            FontStyle subrayado = new FontStyle();//de fuente de un texto seleccionado
            FontStyle tachado = new FontStyle();//FonStyle Define una estructura que
            FontStyle cursiva = new FontStyle(); // representa el estilo de una fuente
            if (tsbNegrita.Checked)// En funci�n de los checkBox y de su marca
            { // asignamos valor a variables o no
                negrita = FontStyle.Bold;
            }
            if (tsbSubrayado.Checked)
            {
                subrayado = FontStyle.Underline;
            }
            if (tsbTachado.Checked)
            {
                tachado = FontStyle.Strikeout;
            }
            if (tsbCursiva.Checked)
            {
                cursiva = FontStyle.Italic;
            }
            
            new Font(rtbEditor.SelectionFont, negrita | subrayado | tachado | cursiva);
            rtbEditor.Focus();
        }

        private void tsbCursiva_Click(object sender, EventArgs e)
        {
            FontStyle negrita = new FontStyle();//Variables para establecer el estilo
            FontStyle subrayado = new FontStyle();//de fuente de un texto seleccionado
            FontStyle tachado = new FontStyle();//FonStyle Define una estructura que
            FontStyle cursiva = new FontStyle(); // representa el estilo de una fuente
            if (tsbNegrita.Checked)// En funci�n de los checkBox y de su marca
            { // asignamos valor a variables o no
                negrita = FontStyle.Bold;
            }
            if (tsbSubrayado.Checked)
            {
                subrayado = FontStyle.Underline;
            }
            if (tsbTachado.Checked)
            {
                tachado = FontStyle.Strikeout;
            }
            if (tsbCursiva.Checked)
            {
                cursiva = FontStyle.Italic;
            }

            new Font(rtbEditor.SelectionFont, negrita | subrayado | tachado | cursiva);
            rtbEditor.Focus();
        }

        private void tsbSubrayado_Click(object sender, EventArgs e)
        {
            FontStyle negrita = new FontStyle();//Variables para establecer el estilo
            FontStyle subrayado = new FontStyle();//de fuente de un texto seleccionado
            FontStyle tachado = new FontStyle();//FonStyle Define una estructura que
            FontStyle cursiva = new FontStyle(); // representa el estilo de una fuente
            if (tsbNegrita.Checked)// En funci�n de los checkBox y de su marca
            { // asignamos valor a variables o no
                negrita = FontStyle.Bold;
            }
            if (tsbSubrayado.Checked)
            {
                subrayado = FontStyle.Underline;
            }
            if (tsbTachado.Checked)
            {
                tachado = FontStyle.Strikeout;
            }
            if (tsbCursiva.Checked)
            {
                cursiva = FontStyle.Italic;
            }

            new Font(rtbEditor.SelectionFont, negrita | subrayado | tachado | cursiva);
            rtbEditor.Focus();
        }

        private void tsbTachado_Click(object sender, EventArgs e)
        {
            FontStyle negrita = new FontStyle();//Variables para establecer el estilo
            FontStyle subrayado = new FontStyle();//de fuente de un texto seleccionado
            FontStyle tachado = new FontStyle();//FonStyle Define una estructura que
            FontStyle cursiva = new FontStyle(); // representa el estilo de una fuente
            if (tsbNegrita.Checked)// En funci�n de los checkBox y de su marca
            { // asignamos valor a variables o no
                negrita = FontStyle.Bold;
            }
            if (tsbSubrayado.Checked)
            {
                subrayado = FontStyle.Underline;
            }
            if (tsbTachado.Checked)
            {
                tachado = FontStyle.Strikeout;
            }
            if (tsbCursiva.Checked)
            {
                cursiva = FontStyle.Italic;
            }

            new Font(rtbEditor.SelectionFont, negrita | subrayado | tachado | cursiva);
            rtbEditor.Focus();
        }
        void desmarca()
        {
            tsbAlineaIzq.Checked = false;
            tsbAlineaCentro.Checked = false;
            tsbAlineaDer.Checked = false;
            for (int i = 0; i < itJustificacion.DropDownItems.Count; i++)
            {//repetir tantas veces como items tiene itJustificacion
                ((ToolStripMenuItem)itJustificacion.DropDownItems[i]).Checked = false;
            }
        }

        private void tsbAlineaIzq_Click(object sender, EventArgs e)
        {
            desmarca();
            tsbAlineaIzq.Checked = true;
            itIzq.Checked = true;
            rtbEditor.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void tsbAlineaCentro_Click(object sender, EventArgs e)
        {
            desmarca();
            tsbAlineaCentro.Checked = true;
            itCentro.Checked = true;
            rtbEditor.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void tsbAlineaDer_Click(object sender, EventArgs e)
        {
            desmarca();
            tsbAlineaDer.Checked = true;
            itDer.Checked = true;
            rtbEditor.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void cbFuentes_TextChanged(object sender, EventArgs e)
        {
            //recoger estilo y tama�o para completar selectionFont
            FontStyle estilo = new FontStyle();
            estilo = rtbEditor.SelectionFont.Style;
            float tamanyo = rtbEditor.SelectionFont.Size;
            string fuente = cbFuentes.Text; //Aplicamos nueva fuente
            rtbEditor.SelectionFont = new Font(fuente, tamanyo, estilo);
            rtbEditor.Focus();
        }
        private void cbTamanyo_TextChanged(object sender, EventArgs e)
        {
            FontStyle estilo = new FontStyle();//definimos variable FontStyle
            estilo = rtbEditor.SelectionFont.Style; //guardamos estilo del
                                                    // texto seleccionado
            string fuente = rtbEditor.SelectionFont.Name; //guardamos fuente
            if (cbTamanyo.Text != "")
            { //Aplicamos solo nuevo tama�o dejando el resto como estaba
                rtbEditor.SelectionFont =
                new Font(fuente, Convert.ToInt32(cbTamanyo.Text), estilo);
            }
        }

        private void tsbPaleta_Click(object sender, EventArgs e)
        {
            dlgColores.Color = rtbEditor.SelectionColor; //Asignamos color de la
                                                       // fuente para que el di�logo lo tenga seleccionado
            if (dlgColores.ShowDialog() == DialogResult.OK) //Ejecutamos el di�logo
            { // Si se ha pulsado el bot�n Aceptar, aplicamos el color del di�logo
                rtbEditor.SelectionColor = dlgColores.Color; // al texto seleccionado
                rtbEditor.Modified = true;
            }
        }

        private void itColorDeFondo_Click(object sender, EventArgs e)
        {
            dlgColores.Color = rtbEditor.BackColor;
            if (dlgColores.ShowDialog() == DialogResult.OK)
            {
                rtbEditor.BackColor = dlgColores.Color;
                rtbEditor.Modified = true;
            }
        }
        private void itAbrir_Click(object sender, EventArgs e)
        {
            stEstadoEditor.Items[0].Text = "Abriendo Archivo de diferentes formatos";
            if (rtbEditor.Modified) // True si hay cambios sobre el editor
            {
                DialogResult resultado = MessageBox.Show("Hay Cambios sin Guardar. Guardas ? ", "Guardar Cambios", MessageBoxButtons.YesNoCancel);
            switch (resultado)
                {
                    case DialogResult.Yes: // Si contesta si
                        itGuardar.PerformClick();// Invocamos evento bot�n guardar
                        break; //Despu�s de Guardar Continuamos con operaci�n de abrir
                    case DialogResult.Cancel: // Si decide cancelar
                        rtbEditor.Focus(); // Enviamos foco al editor
                        return; // Abortamos operaci�n de abrir
                }
            }
            if (dlgAbrir.ShowDialog() == DialogResult.OK // Mostramos di�logo
            && dlgAbrir.FileName.Length > 0)
            { // Si ha pulsado aceptar y elegido un archivo
                if (dlgAbrir.FilterIndex == 1)
                { //Abrimos archivo elegido en el di�logo que tiene FileName
                    rtbEditor.LoadFile(dlgAbrir.FileName, //Par�metro 2 indica
                    RichTextBoxStreamType.PlainText); //formato contenido
                }
                else
                {
                    rtbEditor.LoadFile(dlgAbrir.FileName, // Lo mismo con rtf
                    RichTextBoxStreamType.RichText);
                }
                Text = dlgAbrir.FileName; //Mostramos nuevo nombre barra t�tulo
                rtbEditor.Modified = false; //Sin cambios pendientes de guardar
            }
            stEstadoEditor.Items[0].Text = "";
            itQuitarFormatos.PerformClick(); //Asignamos valores iniciales al editor
            rtbEditor.Focus();
        }

        private void itGuardarComo_Click(object sender, EventArgs e)
        {
            dlgGuardar.FileName = Text; //Asignamos nombre del text del formulario
                                        // a la propiedad FileName del di�logo
            if (dlgGuardar.ShowDialog() == DialogResult.OK && //Si pulsa Aceptar
            dlgGuardar.FileName.Length > 0) // y hay nombre asignado
            {
                if (dlgGuardar.FilterIndex == 1) //Averiguamos formato elegido
                {
                    rtbEditor.SaveFile(dlgGuardar.FileName, //Texto plano
                    RichTextBoxStreamType.PlainText);
                }
                else
                {
                    rtbEditor.SaveFile(dlgGuardar.FileName, // Texto enriquecido
                    RichTextBoxStreamType.RichText);
                }
                Text = dlgGuardar.FileName; //Ponemos en barra de t�tulo del
                                            // formulario el nombre por si ha cambiado
                rtbEditor.Modified = false;
            }
        }

        private void tsbAbrir_Click(object sender, EventArgs e)
        {

        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            if (Text == "Documento1")
            {
                itGuardarComo.PerformClick();
            }
            else
            { // La comprobaci�n, si es texto plano o rtf en guardar como
                rtbEditor.SaveFile(Text);
                rtbEditor.Modified = false;
                rtbEditor.Focus();
            }
        }

        private void itNuevo_Click(object sender, EventArgs e)
        {
            stEstadoEditor.Items[0].Text = "Generando un documento nuevo, guardando el anterior si procede";
            if (rtbEditor.Modified) // True si ha habido cambios en el editor
            {
                DialogResult resultado = MessageBox.Show("Hay Cambios pendientes de Guardar.Guardas ? ","Guardar Cambios", MessageBoxButtons.YesNoCancel);
                switch (resultado)
                {
                    case DialogResult.Yes: //Si contesta s� guardamos
                        itGuardar.PerformClick();//De guardar puede ir a Guarda como
                        break;
                    case DialogResult.Cancel: //Cancela operaci�n de nuevo documento
                        rtbEditor.Focus();
                        return; // Salimos de la funci�n
                }
            } // Si ha contestado si o no, iniciamos nuevo documento
            rtbEditor.Clear(); //Borra todo el contenido del editor
            Text = "Documento2"; //Propone un nuevo nombre y lo asigna al t�tulo
            itQuitarFormatos.PerformClick(); // Ponemos valores por defecto
            rtbEditor.Modified = false; // De momento no hay cambios pendientes
            stEstadoEditor.Items[0].Text = "";
        
    }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            stEstadoEditor.Items[0].Text = "Generando un documento nuevo, guardando el anterior si procede";
            if (rtbEditor.Modified) // True si ha habido cambios en el editor
            {
                DialogResult resultado = MessageBox.Show("Hay Cambios pendientes de Guardar.Guardas ? ", "Guardar Cambios", MessageBoxButtons.YesNoCancel);
                switch (resultado)
                {
                    case DialogResult.Yes: //Si contesta s� guardamos
                        itGuardar.PerformClick();//De guardar puede ir a Guarda como
                        break;
                    case DialogResult.Cancel: //Cancela operaci�n de nuevo documento
                        rtbEditor.Focus();
                        return; // Salimos de la funci�n
                }
            } // Si ha contestado si o no, iniciamos nuevo documento
            rtbEditor.Clear(); //Borra todo el contenido del editor
            Text = "Documento2"; //Propone un nuevo nombre y lo asigna al t�tulo
            itQuitarFormatos.PerformClick(); // Ponemos valores por defecto
            rtbEditor.Modified = false; // De momento no hay cambios pendientes
            stEstadoEditor.Items[0].Text = "";
        }
        private void fmEditor_FormClosing(object sender, FormClosingEventArgs e)
        { //Si hay cambios pendientes y hay algo escrito en el editor
            if ((rtbEditor.Modified) && (rtbEditor.Text.Length > 0))
            {
                DialogResult resultado = MessageBox.Show("Hay Cambios pendientes de Guardar.Guardas ? ","Guardar Cambios", MessageBoxButtons.YesNoCancel);
                switch (resultado)
                {
                    case DialogResult.Yes:
                        itGuardar.PerformClick();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true; //anula el cierre del formulario
                        rtbEditor.Focus();
                        break;
                }
            }
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            if (dlgImprimir.ShowDialog() == DialogResult.OK)
            { // Si se puls� el bot�n "Aceptar" , entonces imprimir.
                string texto = rtbEditor.Text;
                char[] seps = { '\n', '\r' }; // LF y CR separadores de l�neas
                linea = texto.Split(seps); //Convertimos texto en vector
                totalLineasImpresas = 0;
                prindocEditor.Print(); //invoca al otro componente necesario
            }
        }

        private void itImprimir_Click(object sender, EventArgs e)
        {
            if (dlgImprimir.ShowDialog() == DialogResult.OK)
            { // Si se puls� el bot�n "Aceptar" , entonces imprimir.
                string texto = rtbEditor.Text;
                char[] seps = { '\n', '\r' }; // LF y CR separadores de l�neas
                linea = texto.Split(seps); //Convertimos texto en vector
                totalLineasImpresas = 0;
                prindocEditor.Print(); //invoca al otro componente necesario
            }
        }
        private void prindocEditor_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Variables para l�neas por p�gina, posici�n l�nea Y , m�rgenes
            float lineasPorPag;
            float pos_Y;
            float margenIzq = e.MarginBounds.Left; //Obtenemos estos datos por
            float margenSup = e.MarginBounds.Top; // defecto del par�metro
                                                  // Calculamos el n�mero de l�neas por p�gina seg�n tama�o fuente.
                                                  // Los datos de la fuente son los de rtbEditor.Font,salvo el color
            Font fuente = rtbEditor.Font;
            float altoFuente = fuente.GetHeight(e.Graphics);
            lineasPorPag = e.MarginBounds.Height / altoFuente;
            int lineasImpresasPorPag = 0;//Contador de l�neas impresas en 1 p�gina
            while (totalLineasImpresas < linea.Length &&
            lineasImpresasPorPag < lineasPorPag)
            { // Imprimir cada una de las l�neas
                pos_Y = margenSup + (lineasImpresasPorPag * altoFuente); //Pos.L�nea
                                                                         // M�todo que Dibuja la cadena de texto indicada en la ubicaci�n
                                                                         //seleccionada, con objetos brush, Font y format pasados como par�metros
                e.Graphics.DrawString(linea[totalLineasImpresas], fuente,
                Brushes.Black, margenIzq, pos_Y, new StringFormat());
                lineasImpresasPorPag += 1; // L�neas en una p�g.
                totalLineasImpresas += 1; // Total l�neas impresas
            }
            // Si quedan l�neas por imprimir, siguiente p�gina
            if (totalLineasImpresas < linea.Length)
                e.HasMorePages = true; // se invoca de nuevo prinDocEditor_PrintPage
            else
                e.HasMorePages = false; // finaliza la impresi�n
        }

        private void itFuentes_Click(object sender, EventArgs e)
        {
                //Asignamos tipo de fuente y color al dialogo para que el
                // di�logo los muestre y est�n marcados
                dlgFuentes.Color = rtbEditor.SelectionColor;
                dlgFuentes.Font = rtbEditor.SelectionFont;
                if (dlgFuentes.ShowDialog() == DialogResult.OK)
                { // Si pulsa Aceptar aplicamos cambios al texto seleccionado
                    rtbEditor.SelectionFont = dlgFuentes.Font;
                    rtbEditor.SelectionColor = dlgFuentes.Color;
                    rtbEditor_SelectionChanged(sender, e);//Marcamos controles
                                                          // con cambios elegidos en di�logo
                    rtbEditor.Modified = true;
                }
            
        }

        private void rtbEditor_SelectionChanged(object sender, EventArgs e)
        {
            try
            {// Asignamos valores de tama�o, vi�etas, estilo y fuente a los botones
             // e �tems de men� correspondientes, extra�dos de selection y ........
                cbTamanyo.Text =
                Convert.ToString(Math.Truncate(rtbEditor.SelectionFont.Size));
                itVi�etas.Checked = rtbEditor.SelectionBullet;
                tsbNegrita.Checked = rtbEditor.SelectionFont.Bold;
                tsbSubrayado.Checked = rtbEditor.SelectionFont.Underline;
                tsbTachado.Checked = rtbEditor.SelectionFont.Strikeout;
                tsbCursiva.Checked = rtbEditor.SelectionFont.Italic;
                cbFuentes.SelectedIndex =
                cbFuentes.Items.IndexOf(rtbEditor.SelectionFont.Name);
            }
            catch
            {
                return;
            }
            // Marcamos botones e �tems de men� de alineaci�n, seg�n est� en el
            // p�rrafo o l�nea.
            tsbAlineaIzq.Checked = rtbEditor.SelectionAlignment ==
            HorizontalAlignment.Left;
            tsbAlineaDer.Checked = rtbEditor.SelectionAlignment ==
            HorizontalAlignment.Right;
            tsbAlineaCentro.Checked = rtbEditor.SelectionAlignment ==
            HorizontalAlignment.Center;
            itIzq.Checked = tsbAlineaIzq.Checked;
            itDer.Checked = tsbAlineaDer.Checked;
            itCentro.Checked = tsbAlineaCentro.Checked;
        }

        private void tsbCortar_Click(object sender, EventArgs e)
        {
            rtbEditor.Cut();
        }

        private void itCortar_Click(object sender, EventArgs e)
        {
            rtbEditor.Cut();
        }

        private void tsbCopiar_Click(object sender, EventArgs e)
        {
            rtbEditor.Copy();
        }

        private void itCopiar_Click(object sender, EventArgs e)
        {
            rtbEditor.Copy();
        }

        private void itPegar_Click(object sender, EventArgs e)
        {
            rtbEditor.Paste();
        }

        private void tsbPegar_Click(object sender, EventArgs e)
        {
            rtbEditor.Paste();
        }

        private void tsbDeshacer_Click(object sender, EventArgs e)
        {
            if (rtbEditor.CanUndo)
            {
                rtbEditor.Undo();
            }
        }

        private void itDeshacer_Click(object sender, EventArgs e)
        {
            if (rtbEditor.CanUndo)
            {
                rtbEditor.Undo();
            }
        }

        private void itRehacer_Click(object sender, EventArgs e)
        {
            if (rtbEditor.CanUndo)
            {
                rtbEditor.Undo();
            }
        }

        private void tsbRehacer_Click(object sender, EventArgs e)
        {
            if (rtbEditor.CanUndo)
            {
                rtbEditor.Undo();
            }
        }

        private void itSelecTodo_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectAll();
        }

        private void itBorrar_Click(object sender, EventArgs e)
        {
            if (rtbEditor.SelectionLength > 0)
            {
                rtbEditor.SelectedText = "";
            }
        }

        fmDatos VentanaIntroduccion = new fmDatos();
        private void itIrA_Click(object sender, EventArgs e)
        {
            
            VentanaIntroduccion.tbDato.Clear();// TextBox de fmDatos recordar debe
                                               // estar modifiers=public
            if (VentanaIntroduccion.ShowDialog() == DialogResult.OK)
            {
                int numlinea = 0, conta = 0, acumula = 0;
                try
                { // Convertimos a entero n�mero l�nea tecleado
                    numlinea = Convert.ToInt32(VentanaIntroduccion.tbDato.Text);
                }
                catch (Exception mierror)
                {
                    MessageBox.Show(mierror.Message);
                }
                // Mientras es menor que n�mero de l�nea tecleado y hay l�neas
                while ((conta < (numlinea - 1)) && (conta <
                (rtbEditor.Lines.Length - 1)))
                {//Acumulamos los caracteres +1 <intro> de las l�neas anteriores a
                    acumula += ((rtbEditor.Lines[conta].Length) + 1);//la solicitada
                    conta++;
                } // Enviamos cursor al primer car�cter de la l�nea
                rtbEditor.SelectionStart = acumula;
            }
        }

        fmMargenes VentanaMargenes = new fmMargenes();
        private void itMargenes_Click(object sender, EventArgs e)
        {
            // Ponemos valores actuales de m�rgenes en los comboBox del
            // formulario antes de que se muestre
            VentanaMargenes.cbMargenIzq.Text =
            Convert.ToString(rtbEditor.SelectionIndent);
            VentanaMargenes.cbMargenIzq.Text =
            Convert.ToString(rtbEditor.SelectionRightIndent);
            // Mostramos formulario
            if (VentanaMargenes.ShowDialog() == DialogResult.OK)
            { // Si el usuario ha pulsado Aceptar aplicamos m�rgenes con
              // los valores tecleados en el formulario
                rtbEditor.SelectionRightIndent =
                Convert.ToInt32(VentanaMargenes.cbMargenDer.Text);
                rtbEditor.SelectionIndent =
                Convert.ToInt32(VentanaMargenes.cbMargenIzq.Text);
                rtbEditor.Modified = true;
            }
        }
        private void itVi�etas_Click(object sender, EventArgs e)
        {
            itVi�etas.Checked = !itVi�etas.Checked;
            rtbEditor.SelectionBullet = itVi�etas.Checked;
            rtbEditor.Modified = true;
        }

        private void itBarraEstandar_Click(object sender, EventArgs e)
        {
            itBarraEstandar.Checked = !itBarraEstandar.Checked;
            itcBarraEstandar.Checked = !itcBarraEstandar.Checked;
            // Mostramos barra correspondiente o no
            tsBarraEstandar.Visible = itBarraEstandar.Checked;
        }

        private void itBarraFormato_Click(object sender, EventArgs e)
        {
            itBarraFormato.Checked = !itBarraFormato.Checked;
            itcBarraFormato.Checked = !itcBarraFormato.Checked;
            // Mostramos barra correspondiente o no
            tsBarraFormato.Visible = itBarraFormato.Checked;
        }

        private void itBarraEstado_Click(object sender, EventArgs e)
        {
            itBarraEstado.Checked = !itBarraEstado.Checked;
            itcBarraEstado.Checked = !itcBarraEstado.Checked;
            // Mostramos barra correspondiente o no
        }

        FontStyle miestilo = new FontStyle();
        string mifuente;
        float mitamanyo;
        Color micolor;

        private void tsbCopiarFormatos_Click(object sender, EventArgs e)
        {
            if (tsbCopiarFormatos.Checked)
            { // Aviso en barra de estado de bot�n pulsado y acci�n a realizar
                stEstadoEditor.Items[0].Text = "Vas a copiar formato a la nueva ubicaci�n, donde hagas click";
            }
            else
            {
                stEstadoEditor.Items[0].Text = "";
            }
            //Si el bot�n de copiar formatos est� pulsado, guardamos los formatos
            miestilo = rtbEditor.SelectionFont.Style; //Variables globales
            mifuente = rtbEditor.SelectionFont.Name;
            mitamanyo = rtbEditor.SelectionFont.Size;
            micolor = rtbEditor.SelectionColor;
            //con la propiedad checkonclick se evita poner c�digo de marcado
        }

        private void rtbEditor_MouseDown(object sender, MouseEventArgs e)
        {
            stEstadoEditor.Items[0].Text = "Si el bot�n de copiar formatos est� pulsado se aplicar�n los formatos copiados";
            if (tsbCopiarFormatos.Checked) //Si est� pulsado se aplicar�n formatos
            {
                rtbEditor.SelectionFont = new Font(mifuente, mitamanyo, miestilo);
                rtbEditor.SelectionColor = micolor;
            }
        }
    }
}