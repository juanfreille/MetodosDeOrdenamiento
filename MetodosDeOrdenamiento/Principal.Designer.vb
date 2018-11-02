<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cmdNormal = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtElementos = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picGrafico = New System.Windows.Forms.PictureBox()
        Me.tDesordenar = New System.Windows.Forms.TrackBar()
        Me.chkRepetidos = New System.Windows.Forms.CheckBox()
        Me.cmdCrearVector = New System.Windows.Forms.Button()
        Me.cmdVerVector = New System.Windows.Forms.Button()
        Me.GRILLA = New System.Windows.Forms.DataGridView()
        Me.Datos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tVelocidad = New System.Windows.Forms.TrackBar()
        Me.cmdOptimizada = New System.Windows.Forms.Button()
        Me.cmdInsercion = New System.Windows.Forms.Button()
        Me.cmdBidireccional = New System.Windows.Forms.Button()
        Me.cmdBandera = New System.Windows.Forms.Button()
        Me.cmdMergeSort = New System.Windows.Forms.Button()
        Me.cmdQuickSort = New System.Windows.Forms.Button()
        Me.cmdDirecta = New System.Windows.Forms.Button()
        Me.cmdPlay = New System.Windows.Forms.Button()
        Me.cmdRecargarVector = New System.Windows.Forms.Button()
        Me.lblOrdenado = New System.Windows.Forms.Label()
        Me.gpMediciones = New System.Windows.Forms.GroupBox()
        Me.gpQuick = New System.Windows.Forms.GroupBox()
        Me.lQuick = New System.Windows.Forms.ListBox()
        Me.gpMerge = New System.Windows.Forms.GroupBox()
        Me.lMerge = New System.Windows.Forms.ListBox()
        Me.gpInsercion = New System.Windows.Forms.GroupBox()
        Me.lInsercion = New System.Windows.Forms.ListBox()
        Me.gpDirecta = New System.Windows.Forms.GroupBox()
        Me.lDirecta = New System.Windows.Forms.ListBox()
        Me.gpBidireccional = New System.Windows.Forms.GroupBox()
        Me.lBidireccional = New System.Windows.Forms.ListBox()
        Me.gpOptimizada = New System.Windows.Forms.GroupBox()
        Me.lOptimizada = New System.Windows.Forms.ListBox()
        Me.gpBandera = New System.Windows.Forms.GroupBox()
        Me.lBandera = New System.Windows.Forms.ListBox()
        Me.gpBurbuja = New System.Windows.Forms.GroupBox()
        Me.lBurbuja = New System.Windows.Forms.ListBox()
        Me.chkGraficos = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.chkMonitoreo = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbRepetidos = New System.Windows.Forms.TrackBar()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.picGrafico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tDesordenar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRILLA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tVelocidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpMediciones.SuspendLayout()
        Me.gpQuick.SuspendLayout()
        Me.gpMerge.SuspendLayout()
        Me.gpInsercion.SuspendLayout()
        Me.gpDirecta.SuspendLayout()
        Me.gpBidireccional.SuspendLayout()
        Me.gpOptimizada.SuspendLayout()
        Me.gpBandera.SuspendLayout()
        Me.gpBurbuja.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tbRepetidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNormal
        '
        Me.cmdNormal.Location = New System.Drawing.Point(12, 81)
        Me.cmdNormal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdNormal.Name = "cmdNormal"
        Me.cmdNormal.Size = New System.Drawing.Size(147, 42)
        Me.cmdNormal.TabIndex = 0
        Me.cmdNormal.Text = "Burbuja Normal"
        Me.cmdNormal.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Elementos:"
        '
        'txtElementos
        '
        Me.txtElementos.Location = New System.Drawing.Point(99, 28)
        Me.txtElementos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtElementos.Name = "txtElementos"
        Me.txtElementos.Size = New System.Drawing.Size(100, 22)
        Me.txtElementos.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(213, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Desordenar:"
        '
        'picGrafico
        '
        Me.picGrafico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picGrafico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picGrafico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picGrafico.Location = New System.Drawing.Point(3, 17)
        Me.picGrafico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picGrafico.Name = "picGrafico"
        Me.picGrafico.Size = New System.Drawing.Size(805, 431)
        Me.picGrafico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picGrafico.TabIndex = 12
        Me.picGrafico.TabStop = False
        '
        'tDesordenar
        '
        Me.tDesordenar.AutoSize = False
        Me.tDesordenar.LargeChange = 1
        Me.tDesordenar.Location = New System.Drawing.Point(205, 29)
        Me.tDesordenar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tDesordenar.Maximum = 20
        Me.tDesordenar.Name = "tDesordenar"
        Me.tDesordenar.Size = New System.Drawing.Size(447, 31)
        Me.tDesordenar.TabIndex = 13
        '
        'chkRepetidos
        '
        Me.chkRepetidos.AutoSize = True
        Me.chkRepetidos.Location = New System.Drawing.Point(668, 3)
        Me.chkRepetidos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkRepetidos.Name = "chkRepetidos"
        Me.chkRepetidos.Size = New System.Drawing.Size(135, 21)
        Me.chkRepetidos.TabIndex = 15
        Me.chkRepetidos.Text = "Repetir números"
        Me.chkRepetidos.UseVisualStyleBackColor = True
        '
        'cmdCrearVector
        '
        Me.cmdCrearVector.Location = New System.Drawing.Point(907, 11)
        Me.cmdCrearVector.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdCrearVector.Name = "cmdCrearVector"
        Me.cmdCrearVector.Size = New System.Drawing.Size(96, 42)
        Me.cmdCrearVector.TabIndex = 16
        Me.cmdCrearVector.Text = "Crear Vector"
        Me.cmdCrearVector.UseVisualStyleBackColor = True
        '
        'cmdVerVector
        '
        Me.cmdVerVector.Location = New System.Drawing.Point(1009, 11)
        Me.cmdVerVector.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdVerVector.Name = "cmdVerVector"
        Me.cmdVerVector.Size = New System.Drawing.Size(96, 42)
        Me.cmdVerVector.TabIndex = 17
        Me.cmdVerVector.Text = "Ver Vector"
        Me.cmdVerVector.UseVisualStyleBackColor = True
        '
        'GRILLA
        '
        Me.GRILLA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRILLA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Datos})
        Me.GRILLA.Location = New System.Drawing.Point(985, 67)
        Me.GRILLA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GRILLA.Name = "GRILLA"
        Me.GRILLA.RowTemplate.Height = 24
        Me.GRILLA.Size = New System.Drawing.Size(120, 441)
        Me.GRILLA.TabIndex = 18
        '
        'Datos
        '
        Me.Datos.HeaderText = "Datos"
        Me.Datos.Name = "Datos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(173, 540)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Retardar:"
        '
        'tVelocidad
        '
        Me.tVelocidad.AutoSize = False
        Me.tVelocidad.LargeChange = 1
        Me.tVelocidad.Location = New System.Drawing.Point(239, 536)
        Me.tVelocidad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tVelocidad.Maximum = 20
        Me.tVelocidad.Name = "tVelocidad"
        Me.tVelocidad.Size = New System.Drawing.Size(441, 31)
        Me.tVelocidad.TabIndex = 20
        '
        'cmdOptimizada
        '
        Me.cmdOptimizada.Location = New System.Drawing.Point(12, 188)
        Me.cmdOptimizada.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdOptimizada.Name = "cmdOptimizada"
        Me.cmdOptimizada.Size = New System.Drawing.Size(147, 44)
        Me.cmdOptimizada.TabIndex = 21
        Me.cmdOptimizada.Text = "Burbuja Optimizada"
        Me.cmdOptimizada.UseVisualStyleBackColor = True
        '
        'cmdInsercion
        '
        Me.cmdInsercion.Location = New System.Drawing.Point(12, 353)
        Me.cmdInsercion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdInsercion.Name = "cmdInsercion"
        Me.cmdInsercion.Size = New System.Drawing.Size(147, 44)
        Me.cmdInsercion.TabIndex = 22
        Me.cmdInsercion.Text = "Burbuja por Insercion"
        Me.cmdInsercion.UseVisualStyleBackColor = True
        '
        'cmdBidireccional
        '
        Me.cmdBidireccional.Location = New System.Drawing.Point(12, 243)
        Me.cmdBidireccional.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdBidireccional.Name = "cmdBidireccional"
        Me.cmdBidireccional.Size = New System.Drawing.Size(147, 44)
        Me.cmdBidireccional.TabIndex = 23
        Me.cmdBidireccional.Text = "Burbuja Bidireccional"
        Me.cmdBidireccional.UseVisualStyleBackColor = True
        '
        'cmdBandera
        '
        Me.cmdBandera.Location = New System.Drawing.Point(12, 134)
        Me.cmdBandera.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdBandera.Name = "cmdBandera"
        Me.cmdBandera.Size = New System.Drawing.Size(147, 44)
        Me.cmdBandera.TabIndex = 24
        Me.cmdBandera.Text = "Burbuja c/Bandera"
        Me.cmdBandera.UseVisualStyleBackColor = True
        '
        'cmdMergeSort
        '
        Me.cmdMergeSort.Location = New System.Drawing.Point(12, 408)
        Me.cmdMergeSort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdMergeSort.Name = "cmdMergeSort"
        Me.cmdMergeSort.Size = New System.Drawing.Size(147, 44)
        Me.cmdMergeSort.TabIndex = 25
        Me.cmdMergeSort.Text = "MergeSort"
        Me.cmdMergeSort.UseVisualStyleBackColor = True
        '
        'cmdQuickSort
        '
        Me.cmdQuickSort.Location = New System.Drawing.Point(12, 464)
        Me.cmdQuickSort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdQuickSort.Name = "cmdQuickSort"
        Me.cmdQuickSort.Size = New System.Drawing.Size(147, 44)
        Me.cmdQuickSort.TabIndex = 26
        Me.cmdQuickSort.Text = "QuickSort"
        Me.cmdQuickSort.UseVisualStyleBackColor = True
        '
        'cmdDirecta
        '
        Me.cmdDirecta.Location = New System.Drawing.Point(12, 298)
        Me.cmdDirecta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdDirecta.Name = "cmdDirecta"
        Me.cmdDirecta.Size = New System.Drawing.Size(147, 44)
        Me.cmdDirecta.TabIndex = 27
        Me.cmdDirecta.Text = "Seleción Directa"
        Me.cmdDirecta.UseVisualStyleBackColor = True
        '
        'cmdPlay
        '
        Me.cmdPlay.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPlay.Location = New System.Drawing.Point(703, 522)
        Me.cmdPlay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(53, 47)
        Me.cmdPlay.TabIndex = 31
        Me.cmdPlay.Text = "II"
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'cmdRecargarVector
        '
        Me.cmdRecargarVector.Location = New System.Drawing.Point(924, 537)
        Me.cmdRecargarVector.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdRecargarVector.Name = "cmdRecargarVector"
        Me.cmdRecargarVector.Size = New System.Drawing.Size(181, 31)
        Me.cmdRecargarVector.TabIndex = 33
        Me.cmdRecargarVector.Text = "Cargar Vector Original"
        Me.cmdRecargarVector.UseVisualStyleBackColor = True
        '
        'lblOrdenado
        '
        Me.lblOrdenado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOrdenado.Font = New System.Drawing.Font("Verdana", 7.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblOrdenado.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblOrdenado.Location = New System.Drawing.Point(977, 511)
        Me.lblOrdenado.Name = "lblOrdenado"
        Me.lblOrdenado.Size = New System.Drawing.Size(139, 24)
        Me.lblOrdenado.TabIndex = 34
        Me.lblOrdenado.Text = "Desordenado!"
        Me.lblOrdenado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblOrdenado.Visible = False
        '
        'gpMediciones
        '
        Me.gpMediciones.Controls.Add(Me.gpQuick)
        Me.gpMediciones.Controls.Add(Me.gpMerge)
        Me.gpMediciones.Controls.Add(Me.gpInsercion)
        Me.gpMediciones.Controls.Add(Me.gpDirecta)
        Me.gpMediciones.Controls.Add(Me.gpBidireccional)
        Me.gpMediciones.Controls.Add(Me.gpOptimizada)
        Me.gpMediciones.Controls.Add(Me.gpBandera)
        Me.gpMediciones.Controls.Add(Me.gpBurbuja)
        Me.gpMediciones.Location = New System.Drawing.Point(12, 568)
        Me.gpMediciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpMediciones.Name = "gpMediciones"
        Me.gpMediciones.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpMediciones.Size = New System.Drawing.Size(1093, 137)
        Me.gpMediciones.TabIndex = 45
        Me.gpMediciones.TabStop = False
        Me.gpMediciones.Text = "Mediciones"
        '
        'gpQuick
        '
        Me.gpQuick.Controls.Add(Me.lQuick)
        Me.gpQuick.Location = New System.Drawing.Point(963, 18)
        Me.gpQuick.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpQuick.Name = "gpQuick"
        Me.gpQuick.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpQuick.Size = New System.Drawing.Size(123, 114)
        Me.gpQuick.TabIndex = 52
        Me.gpQuick.TabStop = False
        Me.gpQuick.Text = "QuickSort"
        '
        'lQuick
        '
        Me.lQuick.FormattingEnabled = True
        Me.lQuick.ItemHeight = 16
        Me.lQuick.Location = New System.Drawing.Point(12, 23)
        Me.lQuick.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lQuick.Name = "lQuick"
        Me.lQuick.Size = New System.Drawing.Size(100, 84)
        Me.lQuick.TabIndex = 7
        '
        'gpMerge
        '
        Me.gpMerge.Controls.Add(Me.lMerge)
        Me.gpMerge.Location = New System.Drawing.Point(827, 18)
        Me.gpMerge.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpMerge.Name = "gpMerge"
        Me.gpMerge.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpMerge.Size = New System.Drawing.Size(123, 114)
        Me.gpMerge.TabIndex = 51
        Me.gpMerge.TabStop = False
        Me.gpMerge.Text = "MergeSort"
        '
        'lMerge
        '
        Me.lMerge.FormattingEnabled = True
        Me.lMerge.ItemHeight = 16
        Me.lMerge.Location = New System.Drawing.Point(12, 23)
        Me.lMerge.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lMerge.Name = "lMerge"
        Me.lMerge.Size = New System.Drawing.Size(100, 84)
        Me.lMerge.TabIndex = 6
        '
        'gpInsercion
        '
        Me.gpInsercion.Controls.Add(Me.lInsercion)
        Me.gpInsercion.Location = New System.Drawing.Point(691, 18)
        Me.gpInsercion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpInsercion.Name = "gpInsercion"
        Me.gpInsercion.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpInsercion.Size = New System.Drawing.Size(123, 114)
        Me.gpInsercion.TabIndex = 50
        Me.gpInsercion.TabStop = False
        Me.gpInsercion.Text = "Inserción"
        '
        'lInsercion
        '
        Me.lInsercion.FormattingEnabled = True
        Me.lInsercion.ItemHeight = 16
        Me.lInsercion.Location = New System.Drawing.Point(12, 23)
        Me.lInsercion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lInsercion.Name = "lInsercion"
        Me.lInsercion.Size = New System.Drawing.Size(100, 84)
        Me.lInsercion.TabIndex = 5
        '
        'gpDirecta
        '
        Me.gpDirecta.Controls.Add(Me.lDirecta)
        Me.gpDirecta.Location = New System.Drawing.Point(555, 18)
        Me.gpDirecta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpDirecta.Name = "gpDirecta"
        Me.gpDirecta.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpDirecta.Size = New System.Drawing.Size(123, 114)
        Me.gpDirecta.TabIndex = 49
        Me.gpDirecta.TabStop = False
        Me.gpDirecta.Text = "Selec. Directa"
        '
        'lDirecta
        '
        Me.lDirecta.FormattingEnabled = True
        Me.lDirecta.ItemHeight = 16
        Me.lDirecta.Location = New System.Drawing.Point(12, 23)
        Me.lDirecta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lDirecta.Name = "lDirecta"
        Me.lDirecta.Size = New System.Drawing.Size(100, 84)
        Me.lDirecta.TabIndex = 4
        '
        'gpBidireccional
        '
        Me.gpBidireccional.Controls.Add(Me.lBidireccional)
        Me.gpBidireccional.Location = New System.Drawing.Point(417, 18)
        Me.gpBidireccional.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpBidireccional.Name = "gpBidireccional"
        Me.gpBidireccional.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpBidireccional.Size = New System.Drawing.Size(123, 114)
        Me.gpBidireccional.TabIndex = 48
        Me.gpBidireccional.TabStop = False
        Me.gpBidireccional.Text = "B Bidireccional"
        '
        'lBidireccional
        '
        Me.lBidireccional.FormattingEnabled = True
        Me.lBidireccional.ItemHeight = 16
        Me.lBidireccional.Location = New System.Drawing.Point(12, 23)
        Me.lBidireccional.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lBidireccional.Name = "lBidireccional"
        Me.lBidireccional.Size = New System.Drawing.Size(100, 84)
        Me.lBidireccional.TabIndex = 3
        '
        'gpOptimizada
        '
        Me.gpOptimizada.Controls.Add(Me.lOptimizada)
        Me.gpOptimizada.Location = New System.Drawing.Point(279, 18)
        Me.gpOptimizada.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpOptimizada.Name = "gpOptimizada"
        Me.gpOptimizada.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpOptimizada.Size = New System.Drawing.Size(123, 114)
        Me.gpOptimizada.TabIndex = 47
        Me.gpOptimizada.TabStop = False
        Me.gpOptimizada.Text = "B Optimizada"
        '
        'lOptimizada
        '
        Me.lOptimizada.FormattingEnabled = True
        Me.lOptimizada.ItemHeight = 16
        Me.lOptimizada.Location = New System.Drawing.Point(12, 23)
        Me.lOptimizada.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lOptimizada.Name = "lOptimizada"
        Me.lOptimizada.Size = New System.Drawing.Size(100, 84)
        Me.lOptimizada.TabIndex = 2
        '
        'gpBandera
        '
        Me.gpBandera.Controls.Add(Me.lBandera)
        Me.gpBandera.Location = New System.Drawing.Point(141, 18)
        Me.gpBandera.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpBandera.Name = "gpBandera"
        Me.gpBandera.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpBandera.Size = New System.Drawing.Size(123, 114)
        Me.gpBandera.TabIndex = 46
        Me.gpBandera.TabStop = False
        Me.gpBandera.Text = "B c/Bandera"
        '
        'lBandera
        '
        Me.lBandera.FormattingEnabled = True
        Me.lBandera.ItemHeight = 16
        Me.lBandera.Location = New System.Drawing.Point(12, 23)
        Me.lBandera.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lBandera.Name = "lBandera"
        Me.lBandera.Size = New System.Drawing.Size(100, 84)
        Me.lBandera.TabIndex = 1
        '
        'gpBurbuja
        '
        Me.gpBurbuja.Controls.Add(Me.lBurbuja)
        Me.gpBurbuja.Location = New System.Drawing.Point(5, 18)
        Me.gpBurbuja.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpBurbuja.Name = "gpBurbuja"
        Me.gpBurbuja.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpBurbuja.Size = New System.Drawing.Size(123, 114)
        Me.gpBurbuja.TabIndex = 45
        Me.gpBurbuja.TabStop = False
        Me.gpBurbuja.Text = "Burbuja"
        '
        'lBurbuja
        '
        Me.lBurbuja.FormattingEnabled = True
        Me.lBurbuja.ItemHeight = 16
        Me.lBurbuja.Location = New System.Drawing.Point(12, 23)
        Me.lBurbuja.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lBurbuja.Name = "lBurbuja"
        Me.lBurbuja.Size = New System.Drawing.Size(100, 84)
        Me.lBurbuja.TabIndex = 0
        '
        'chkGraficos
        '
        Me.chkGraficos.AutoSize = True
        Me.chkGraficos.Location = New System.Drawing.Point(174, 516)
        Me.chkGraficos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkGraficos.Name = "chkGraficos"
        Me.chkGraficos.Size = New System.Drawing.Size(151, 21)
        Me.chkGraficos.TabIndex = 46
        Me.chkGraficos.Text = "Animación (On/Off)"
        Me.chkGraficos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 710)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(391, 15)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "(*)  C = Comparaciones // A = Asginaciones // T = Tiempo en segundos"
        '
        'cmdStop
        '
        Me.cmdStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStop.Location = New System.Drawing.Point(779, 522)
        Me.cmdStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(53, 47)
        Me.cmdStop.TabIndex = 48
        Me.cmdStop.Text = "■"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'chkMonitoreo
        '
        Me.chkMonitoreo.AutoSize = True
        Me.chkMonitoreo.Location = New System.Drawing.Point(363, 516)
        Me.chkMonitoreo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkMonitoreo.Name = "chkMonitoreo"
        Me.chkMonitoreo.Size = New System.Drawing.Size(142, 21)
        Me.chkMonitoreo.TabIndex = 49
        Me.chkMonitoreo.Text = "Medición (On/Off)"
        Me.chkMonitoreo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.picGrafico)
        Me.GroupBox1.Location = New System.Drawing.Point(165, 60)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(811, 450)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gráfico"
        '
        'tbRepetidos
        '
        Me.tbRepetidos.AutoSize = False
        Me.tbRepetidos.LargeChange = 1
        Me.tbRepetidos.Location = New System.Drawing.Point(658, 29)
        Me.tbRepetidos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbRepetidos.Maximum = 8
        Me.tbRepetidos.Minimum = 1
        Me.tbRepetidos.Name = "tbRepetidos"
        Me.tbRepetidos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbRepetidos.Size = New System.Drawing.Size(156, 31)
        Me.tbRepetidos.TabIndex = 13
        Me.tbRepetidos.Value = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 520)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 44)
        Me.Button1.TabIndex = 51
        Me.Button1.Text = "Correr TODOS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 729)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbRepetidos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkMonitoreo)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkGraficos)
        Me.Controls.Add(Me.gpMediciones)
        Me.Controls.Add(Me.lblOrdenado)
        Me.Controls.Add(Me.cmdRecargarVector)
        Me.Controls.Add(Me.cmdPlay)
        Me.Controls.Add(Me.cmdDirecta)
        Me.Controls.Add(Me.cmdQuickSort)
        Me.Controls.Add(Me.cmdMergeSort)
        Me.Controls.Add(Me.cmdBandera)
        Me.Controls.Add(Me.cmdBidireccional)
        Me.Controls.Add(Me.cmdInsercion)
        Me.Controls.Add(Me.cmdOptimizada)
        Me.Controls.Add(Me.tVelocidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GRILLA)
        Me.Controls.Add(Me.cmdVerVector)
        Me.Controls.Add(Me.cmdCrearVector)
        Me.Controls.Add(Me.chkRepetidos)
        Me.Controls.Add(Me.tDesordenar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtElementos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdNormal)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Métodos de Ordenamiento"
        CType(Me.picGrafico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tDesordenar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRILLA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tVelocidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpMediciones.ResumeLayout(False)
        Me.gpQuick.ResumeLayout(False)
        Me.gpMerge.ResumeLayout(False)
        Me.gpInsercion.ResumeLayout(False)
        Me.gpDirecta.ResumeLayout(False)
        Me.gpBidireccional.ResumeLayout(False)
        Me.gpOptimizada.ResumeLayout(False)
        Me.gpBandera.ResumeLayout(False)
        Me.gpBurbuja.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tbRepetidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdNormal As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtElementos As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tDesordenar As TrackBar
    Friend WithEvents chkRepetidos As CheckBox
    Friend WithEvents cmdCrearVector As Button
    Friend WithEvents cmdVerVector As Button
    Friend WithEvents GRILLA As DataGridView
    Friend WithEvents Datos As DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents tVelocidad As TrackBar
    Friend WithEvents cmdOptimizada As Button
    Friend WithEvents cmdInsercion As Button
    Friend WithEvents cmdBidireccional As Button
    Friend WithEvents cmdBandera As Button
    Friend WithEvents cmdMergeSort As Button
    Friend WithEvents cmdQuickSort As Button
    Friend WithEvents cmdDirecta As Button
    Friend WithEvents cmdPlay As Button
    Friend WithEvents cmdRecargarVector As Button
    Friend WithEvents lblOrdenado As Label
    Friend WithEvents lblDesordenado As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents gpMediciones As GroupBox
    Friend WithEvents gpQuick As GroupBox
    Friend WithEvents gpMerge As GroupBox
    Friend WithEvents gpInsercion As GroupBox
    Friend WithEvents gpDirecta As GroupBox
    Friend WithEvents gpBidireccional As GroupBox
    Friend WithEvents gpOptimizada As GroupBox
    Friend WithEvents gpBandera As GroupBox
    Friend WithEvents gpBurbuja As GroupBox
    Friend WithEvents lQuick As ListBox
    Friend WithEvents lMerge As ListBox
    Friend WithEvents lInsercion As ListBox
    Friend WithEvents lDirecta As ListBox
    Friend WithEvents lBidireccional As ListBox
    Friend WithEvents lOptimizada As ListBox
    Friend WithEvents lBandera As ListBox
    Friend WithEvents lBurbuja As ListBox
    Friend WithEvents chkGraficos As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmdStop As Button
    Friend WithEvents chkMonitoreo As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents picGrafico As PictureBox
    Friend WithEvents tbRepetidos As TrackBar
    Friend WithEvents Button1 As Button
End Class
