Imports System.ComponentModel

Public Class Principal
    Private Maximizar As New Redimensionar
    Private Cambio As Integer
    Private Lugar As Integer
    Private GraficoOno As Boolean = True
    Private NivelDesorden As Integer
    Private UltimaPosicion As Long
    Private Lienzo As Graphics
    Public THREAD As Threading.Thread
    Private VECTOR_INICIAL As Long()
    Private V As Long()
    Private VD As Long()
    Private MaxValor As Long
    Private Demora As Integer
    Private Repetidos As Integer

    '------------------------------------------------------------------------------------------------------------
    ' Procesos
    '------------------------------------------------------------------------------------------------------------
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Usar el class de redimension
        Maximizar.FindAllControls(Me)

        'Crear el objeto gráfico
        Lienzo = picGrafico.CreateGraphics

        'Inicializamos los botones de la grafica en invisibles
        cmdPlay.Visible = False
        cmdStop.Visible = False

        'Para acceder a los controles del form desde los hilos
        CheckForIllegalCrossThreadCalls = False

        'Variables inicializacion
        chkGraficos.Checked = True
        chkMonitoreo.Checked = False

        'Una chanchada para poder utilizar el picturebox en resolucion normal/maximizada
        Me.WindowState = FormWindowState.Maximized
        Me.WindowState = FormWindowState.Normal

    End Sub

    '------------------------------------------------------------------------------------------------------------
    'Metodos de ordenamiento
    '------------------------------------------------------------------------------------------------------------
    '1  Burbuja Normal
    '------------------------------------------------------------------------------------------------------------

    'Grafico
    Public Sub BurbujaNormal()
        Dim i As Long, Limite As Long
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
        Cursor = Cursors.WaitCursor
        If chkGraficos.Checked Then
            InicioDeBotones()
        End If
        cAsignaciones = cAsignaciones + 1
        Limite = UltimaPosicion
        cCondicionales = cCondicionales + 1
        While Limite > 0
            cAsignaciones = cAsignaciones + 1
            i = 0
            cCondicionales = cCondicionales + 1
            While i < Limite
                cCondicionales = cCondicionales + 1
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Yellow, i)
                    GraficarBarra(Brushes.Yellow, i + 1)
                    Threading.Thread.Sleep(Demora)
                End If
                If V(i) > V(i + 1) Then
                    cAsignaciones = cAsignaciones + 3
                    CambiarElementos(V, i, i + 1)
                    If chkGraficos.Checked Then
                        GraficarBarra(Brushes.Orange, i)
                        GraficarBarra(Brushes.Orange, i + 1)
                        Threading.Thread.Sleep(Demora * 2)
                    End If
                End If
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Blue, i)
                    GraficarBarra(Brushes.Blue, i + 1)
                End If
                cAsignaciones = cAsignaciones + 1
                i = i + 1
            End While
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Green, Limite)
            End If
            cAsignaciones = cAsignaciones + 1
            Limite = Limite - 1
        End While
        If chkGraficos.Checked Then
            GraficarBarra(Brushes.Green, 0)
        End If
        FinalDeBotones()
        lBurbuja.Items.Clear()
        lBurbuja.Items.Add("C: " & cCondicionales)
        lBurbuja.Items.Add("A: " & cAsignaciones)
        BurbujaNormal_Datos()
        Cursor = Cursors.Default
        Me.Text = "Métodos de Ordenamiento"
    End Sub

    'Datos
    Public Sub BurbujaNormal_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim i As Long, Limite As Long

        'Tomar tiempo actual
        TiempoInicial = Now
        Limite = UltimaPosicion
        While Limite > 0
            i = 0
            While i < Limite
                If VD(i) > VD(i + 1) Then
                    CambiarElementos(VD, i, i + 1)
                End If
                i = i + 1
            End While
            Limite = Limite - 1
        End While

        'Tomar tiempo final
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lBurbuja.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
        GraficarVector(Brushes.Green)
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '2 Burbuja Con Bandera (Salir si ya esta ordenado)
    '------------------------------------------------------------------------------------------------------------
    'Grafico
    Private Sub BurbujaBandera()
        Dim i As Long = 0
        Dim Limite As Long
        Dim HuboCambio As Boolean
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
        Cursor = Cursors.WaitCursor
        If chkGraficos.Checked Then
            InicioDeBotones()
        End If

        cAsignaciones = cAsignaciones + 1
        HuboCambio = True
        Limite = UltimaPosicion
        cAsignaciones = cAsignaciones + 1
        While Limite > 0 And HuboCambio
            '            GraficarBarra(Brushes.Red, Limite)
            HuboCambio = False
            cAsignaciones = cAsignaciones + 1
            i = 0
            cCondicionales = cCondicionales + 1
            While i < Limite
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Yellow, i)
                    GraficarBarra(Brushes.Yellow, i + 1)
                    Threading.Thread.Sleep(Demora * 2)
                End If
                cCondicionales = cCondicionales + 1
                If V(i) > V(i + 1) Then
                    HuboCambio = True
                    cAsignaciones = cAsignaciones + 3
                    CambiarElementos(V, i, (i + 1))
                    If chkGraficos.Checked Then
                        GraficarBarra(Brushes.Orange, i)
                        GraficarBarra(Brushes.Orange, i + 1)
                        Threading.Thread.Sleep(Demora * 2)
                    End If
                End If
                cAsignaciones = cAsignaciones + 1
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Blue, i)
                    Threading.Thread.Sleep(Demora * 2)
                End If
                i = i + 1
            End While
            cAsignaciones = cAsignaciones + 1
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Green, Limite)
            End If
            Limite = Limite - 1
        End While

        If chkGraficos.Checked Then
            For i = 0 To Limite
                GraficarBarra(Brushes.Green, i)
            Next
        End If

        lBandera.Items.Clear()
        lBandera.Items.Add("C: " & cCondicionales)
        lBandera.Items.Add("A: " & cAsignaciones)

        BurbujaBandera_Datos()
        FinalDeBotones()
        Cursor = Cursors.Default
        Me.Text = "Métodos de Ordenamiento"
    End Sub

    'Datos
    Private Sub BurbujaBandera_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim i As Long = 0
        Dim Limite As Long
        Dim HuboCambio As Boolean

        'Tomar tiempo actual
        TiempoInicial = Now
        HuboCambio = True
        Limite = UltimaPosicion
        While Limite > 0 And HuboCambio
            HuboCambio = False
            i = 0
            While i < Limite
                If VD(i) > VD(i + 1) Then
                    HuboCambio = True
                    CambiarElementos(VD, i, (i + 1))
                End If
                i = i + 1
            End While
            Limite = Limite - 1
        End While

        'Tomar tiempo final
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lBandera.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
        GraficarVector(Brushes.Green)
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '3 Burbuja Optimizada (Posicion Ultimo Cambio)
    '------------------------------------------------------------------------------------------------------------
    'Grafico
    Private Sub BurbujaOptimizada()
        Dim i As Long = 0
        Dim PUC As Long
        Dim Limite As Long
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
        Cursor = Cursors.WaitCursor
        If chkGraficos.Checked Then
            InicioDeBotones()
        End If

        cAsignaciones = cAsignaciones + 1
        Limite = UltimaPosicion
        cCondicionales = cCondicionales + 1

        While Limite > 0
            cAsignaciones = cAsignaciones + 1
            i = 0
            cAsignaciones = cAsignaciones + 1
            PUC = 0
            cCondicionales = cCondicionales + 1
            While i < Limite
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Yellow, i)
                    GraficarBarra(Brushes.Yellow, i + 1)
                    Threading.Thread.Sleep(Demora)
                End If
                cCondicionales = cCondicionales + 1
                If V(i) > V(i + 1) Then
                    cAsignaciones = cAsignaciones + 4
                    CambiarElementos(V, i, (i + 1))
                    PUC = i
                    If chkGraficos.Checked Then
                        GraficarBarra(Brushes.Orange, i)
                        GraficarBarra(Brushes.Orange, i + 1)
                        Threading.Thread.Sleep(Demora * 2)
                    End If
                End If
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Blue, i)
                    GraficarBarra(Brushes.Blue, i + 1)
                End If
                cAsignaciones = cAsignaciones + 1
                i = i + 1
            End While
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Green, Limite)
            End If
            cAsignaciones = cAsignaciones + 1
            Limite = PUC
        End While
        If chkGraficos.Checked Then
            GraficarBarra(Brushes.Green, 0)
        End If

        lOptimizada.Items.Clear()
        lOptimizada.Items.Add("C: " & cCondicionales)
        lOptimizada.Items.Add("A: " & cAsignaciones)

        BurbujaOptimizada_Datos()
        FinalDeBotones()
        Cursor = Cursors.Default
        Me.Text = "Métodos de Ordenamiento"
    End Sub

    'Datos
    Private Sub BurbujaOptimizada_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim i As Long = 0
        Dim PUC As Long
        Dim Limite As Long

        'Tomar tiempo actual
        TiempoInicial = Now
        Limite = UltimaPosicion

        While Limite > 0
            i = 0
            PUC = 0
            While i < Limite
                If VD(i) > VD(i + 1) Then
                    CambiarElementos(VD, i, (i + 1))
                    PUC = i
                End If
                i = i + 1
            End While
            Limite = PUC
        End While

        'Tomar tiempo final
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lOptimizada.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
        GraficarVector(Brushes.Green)
    End Sub
    '------------------------------------------------------------------------------------------------------------
    '4 Burbuja Bidireccional
    '------------------------------------------------------------------------------------------------------------
    'Grafico

    Private Sub BurbujaBidireccional()
        Dim posic As Long = 0
        Dim iMax As Long
        Dim iMin As Long
        Dim i As Long
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
        Cursor = Cursors.WaitCursor
        If chkGraficos.Checked Then
            InicioDeBotones()
        End If

        cAsignaciones = cAsignaciones + 1
        iMax = UltimaPosicion
        cCondicionales = cCondicionales + 1

        While posic < iMax
            cAsignaciones = cAsignaciones + 2
            iMin = posic
            i = posic
            cCondicionales = cCondicionales + 1
            While i < iMax
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Yellow, i)
                    GraficarBarra(Brushes.Yellow, i + 1)
                    Threading.Thread.Sleep(Demora)
                End If
                cCondicionales = cCondicionales + 1
                If V(i) > V(i + 1) Then
                    cAsignaciones = cAsignaciones + 4
                    CambiarElementos(V, i, (i + 1))
                    iMin = i
                    If chkGraficos.Checked Then
                        GraficarBarra(Brushes.Orange, i)
                        GraficarBarra(Brushes.Orange, i + 1)
                        Threading.Thread.Sleep(Demora)
                    End If
                End If
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Blue, i)
                    GraficarBarra(Brushes.Blue, i + 1)
                End If
                cAsignaciones = cAsignaciones + 1
                i = i + 1
            End While
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Green, iMax)
            End If
            cAsignaciones = cAsignaciones + 2
            iMax = iMin
            i = iMax
            cCondicionales = cCondicionales + 1
            While i > posic
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Yellow, i)
                    GraficarBarra(Brushes.Yellow, i - 1)
                    Threading.Thread.Sleep(Demora)
                End If
                cCondicionales = cCondicionales + 1
                If V(i) < V(i - 1) Then
                    cAsignaciones = cAsignaciones + 4
                    CambiarElementos(V, i, (i - 1))
                    iMin = i
                    If chkGraficos.Checked Then
                        GraficarBarra(Brushes.Orange, i)
                        GraficarBarra(Brushes.Orange, i - 1)
                        Threading.Thread.Sleep(Demora)
                    End If
                End If
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Blue, i)
                    GraficarBarra(Brushes.Blue, i - 1)
                End If
                cAsignaciones = cAsignaciones + 1
                i = i - 1
            End While
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Green, posic)
            End If
            cAsignaciones = cAsignaciones + 1
            posic = iMin
        End While
        If chkGraficos.Checked Then
            GraficarBarra(Brushes.Green, i)
            GraficarBarra(Brushes.Green, i + 1)
        End If

        lBidireccional.Items.Clear()
        lBidireccional.Items.Add("C: " & cCondicionales)
        lBidireccional.Items.Add("A: " & cAsignaciones)

        BurbujaBidireccional_Datos()
        FinalDeBotones()
        Cursor = Cursors.Default
        Me.Text = "Métodos de Ordenamiento"
    End Sub

    'Datos
    Private Sub BurbujaBidireccional_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim posic As Long = 0
        Dim iMax As Long
        Dim iMin As Long
        Dim i As Long

        'Tomar tiempo actual
        TiempoInicial = Now
        iMax = UltimaPosicion

        While posic < iMax
            iMin = posic
            i = posic
            While i < iMax
                If VD(i) > VD(i + 1) Then
                    CambiarElementos(V, i, (i + 1))
                    iMin = i
                End If
                i = i + 1
            End While
            iMax = iMin
            i = iMax
            While i > posic
                If VD(i) < VD(i - 1) Then
                    CambiarElementos(V, i, (i - 1))
                    iMin = i
                End If
                i = i - 1
            End While
            posic = iMin
        End While

        'Tomar tiempo final
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lBidireccional.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
        GraficarVector(Brushes.Green)
    End Sub


    '------------------------------------------------------------------------------------------------------------
    '5 Selección Directa (Termina cuando la variable base llega al ultimo). Es un metodo no adaptativo, no es 
    'capaz de mejorar su desempeño. Es el metodo que menos intercambios realiza.
    '------------------------------------------------------------------------------------------------------------
    'Grafico
    Private Sub SeleccionDirecta()
        Dim Base As Long
        Dim Menor As Long
        Dim i As Long
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
        Cursor = Cursors.WaitCursor
        If chkGraficos.Checked Then
            InicioDeBotones()
        End If

        cAsignaciones = cAsignaciones + 1
        Base = 0
        cCondicionales = cCondicionales + 1
        While Base < UltimaPosicion
            cAsignaciones = cAsignaciones + 2
            Menor = Base
            i = Base + 1
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Blue, i)
            End If
            cCondicionales = cCondicionales + 1
            While i <= UltimaPosicion
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Blue, Menor)
                End If
                cCondicionales = cCondicionales + 1
                If V(i) < V(Menor) Then
                    cAsignaciones = cAsignaciones + 1
                    Menor = i
                    If chkGraficos.Checked Then
                        GraficarBarra(Brushes.Green, Menor)
                    End If
                End If
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Orange, Menor)
                    GraficarBarra(Brushes.Yellow, i)
                    Threading.Thread.Sleep(Demora * 2)
                End If
                cAsignaciones = cAsignaciones + 1
                i = i + 1
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Blue, i - 1)
                End If
            End While
            cAsignaciones = cAsignaciones + 4
            CambiarElementos(V, Base, Menor)
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Blue, Menor)
                GraficarBarra(Brushes.Green, Base)
                Threading.Thread.Sleep(Demora)
            End If
            Base = Base + 1
        End While
        If chkGraficos.Checked Then
            GraficarBarra(Brushes.Green, i - 1)
        End If

        lDirecta.Items.Clear()
        lDirecta.Items.Add("C: " & cCondicionales)
        lDirecta.Items.Add("A: " & cAsignaciones)
        SeleccionDirecta_Datos()
        FinalDeBotones()
        Cursor = Cursors.Default
        Me.Text = "Métodos de Ordenamiento"
    End Sub

    'Datos
    Private Sub SeleccionDirecta_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim Base As Long
        Dim Menor As Long
        Dim i As Long

        'Tomar tiempo actual
        TiempoInicial = Now
        Base = 0
        While Base < UltimaPosicion
            Menor = Base
            i = Base + 1
            While i <= UltimaPosicion
                If VD(i) < VD(Menor) Then
                    Menor = i
                End If
                i = i + 1
            End While
            CambiarElementos(VD, Base, Menor)
            Base = Base + 1
        End While

        'Tomar tiempo final
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lDirecta.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
        GraficarVector(Brushes.Green)
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '6 Burbuja con Inserción: Se parte lo ordenado de lo desordenado de un vector.
    '
    ' Codigo elegante, lo que tiene de ventaja es que no hace intercambios, sino que desplaza. Mueve menos datos. 
    '------------------------------------------------------------------------------------------------------------
    'Grafico
    Private Sub BurbujaConInsercion()
        Dim aux As Long
        Dim Frontera As Long
        Dim i As Long
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
        Cursor = Cursors.WaitCursor
        If chkGraficos.Checked Then
            InicioDeBotones()
        End If

        cAsignaciones = cAsignaciones + 1
        Frontera = 1 'Segundo elemento, porque asumimos que el primer elemento esta ordenado
        cCondicionales = cCondicionales + 1
        While Frontera <= UltimaPosicion
            cAsignaciones = cAsignaciones + 2
            aux = V(Frontera)
            i = Frontera - 1
            cCondicionales = cCondicionales + 1
            While i >= 0 AndAlso V(i) > aux
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Blue, i)
                    GraficarBarra(Brushes.Green, Frontera)
                End If
                cAsignaciones = cAsignaciones + 2
                V(i + 1) = V(i)
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Orange, i)
                    Threading.Thread.Sleep(Demora * 2)
                    GraficarBarra(Brushes.Blue, i + 1)
                    Threading.Thread.Sleep(Demora * 2)
                End If
                i = i - 1
            End While
            If chkGraficos.Checked Then

                GraficarBarra(Brushes.Green, Frontera)
                GraficarBarra(Brushes.Blue, i + 1)
            End If
            cAsignaciones = cAsignaciones + 2
            V(i + 1) = aux
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Blue, i + 1)
                Threading.Thread.Sleep(Demora * 10)
                GraficarBarra(Brushes.Green, Frontera)
                Threading.Thread.Sleep(Demora * 2)
            End If
            Frontera = Frontera + 1
        End While
        If chkGraficos.Checked Then
            GraficarBarra(Brushes.Green, 0)
        End If

        If chkGraficos.Checked Then
            For i = 0 To UltimaPosicion
                GraficarBarra(Brushes.Orange, i)
                Threading.Thread.Sleep(Demora * 5)
                GraficarBarra(Brushes.Green, i)
                Threading.Thread.Sleep(Demora * 10)
            Next
        End If

        lInsercion.Items.Clear()
        lInsercion.Items.Add("C: " & cCondicionales)
        lInsercion.Items.Add("A: " & cAsignaciones)
        FinalDeBotones()
        BurbujaConInsercion_Datos()
        Cursor = Cursors.Default
        Me.Text = "Métodos de Ordenamiento"
    End Sub

    'Datos
    Private Sub BurbujaConInsercion_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim aux
        Dim Frontera
        Dim i

        'Tomar tiempo actual
        TiempoInicial = Now
        Frontera = 1
        While Frontera <= UltimaPosicion
            aux = VD(Frontera)
            i = Frontera - 1
            While i >= 0 AndAlso VD(i) > aux
                VD(i + 1) = VD(i)
                i = i - 1
            End While
            VD(i + 1) = aux
            Frontera = Frontera + 1
        End While

        'Tomar tiempo final
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lInsercion.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
        GraficarVector(Brushes.Green)
    End Sub


    '------------------------------------------------------------------------------------------------------------
    '7 Merge Sort: Tiene una eficiencia similar al quick sort (si el quick sort esta en condiciones ideales, es
    'decir muy desordenado). Lo bueno de este metodo es que mientras mas elementos tiene para ordenar menor 
    'sera el tiempo que va a tardar y mas eficientemente lo hara.
    '------------------------------------------------------------------------------------------------------------
    'Grafico
    Sub MergeSort()
        Dim IzqA, DerA, IzqB, DerB As Integer
        Dim AnchoSeccion As Integer
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
        Cursor = Cursors.WaitCursor
        If chkGraficos.Checked Then
            InicioDeBotones()
        End If

        cAsignaciones = cAsignaciones + 1
        AnchoSeccion = 1
        cCondicionales = cCondicionales + 1
        While AnchoSeccion <= UltimaPosicion
            cAsignaciones = cAsignaciones + 4
            IzqA = 0
            DerA = IzqA + AnchoSeccion - 1
            IzqB = DerA + 1
            DerB = IzqB + AnchoSeccion - 1
            cCondicionales = cCondicionales + 1
            If DerB > UltimaPosicion Then
                cAsignaciones = cAsignaciones + 1
                DerB = UltimaPosicion
            End If
            cCondicionales = cCondicionales + 1
            While IzqB <= UltimaPosicion
                MezclarVector(IzqA, DerA, IzqB, DerB, V)
                cAsignaciones = cAsignaciones + 4
                IzqA = DerB + 1
                DerA = IzqA + AnchoSeccion - 1
                IzqB = DerA + 1
                DerB = IzqB + AnchoSeccion - 1
                cCondicionales = cCondicionales + 1
                If DerB > UltimaPosicion Then
                    cAsignaciones = cAsignaciones + 1
                    DerB = UltimaPosicion
                End If
            End While
            cAsignaciones = cAsignaciones + 1
            AnchoSeccion = AnchoSeccion * 2
        End While

        lMerge.Items.Clear()
        lMerge.Items.Add("C: " & cCondicionales)
        lMerge.Items.Add("A: " & cAsignaciones)
        MergeSort_Datos()
        FinalDeBotones()
        Cursor = Cursors.Default
        Me.Text = "Métodos de Ordenamiento"
    End Sub

    'Datos
    Sub MergeSort_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim IzqA, DerA, IzqB, DerB As Integer
        Dim AnchoSeccion As Integer

        'Tomar tiempo actual
        TiempoInicial = Now
        AnchoSeccion = 1

        While AnchoSeccion <= UltimaPosicion
            IzqA = 0
            DerA = IzqA + AnchoSeccion - 1
            IzqB = DerA + 1
            DerB = IzqB + AnchoSeccion - 1
            If DerB > UltimaPosicion Then
                DerB = UltimaPosicion
            End If
            While IzqB <= UltimaPosicion
                MezclarVector(IzqA, DerA, IzqB, DerB, VD)
                IzqA = DerB + 1
                DerA = IzqA + AnchoSeccion - 1
                IzqB = DerA + 1
                DerB = IzqB + AnchoSeccion - 1
                If DerB > UltimaPosicion Then
                    DerB = UltimaPosicion
                End If
            End While
            AnchoSeccion = AnchoSeccion * 2
        End While

        'Tomar tiempo final
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lMerge.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
        GraficarVector(Brushes.Green)
    End Sub
    Sub MezclarVector(iA As Integer, dA As Integer, iB As Integer, dB As Integer, vector() As Long)
        Dim VAux(dB - iA) As Integer 'Crea el vector auxiliar donde realizar la mezcla o combinación
        Dim i As Integer, iInicio As Integer = iA
        'Mezclar en VAux() hasta que A() o B() lleguen a su final
        i = 0
        While iA <= dA And iB <= dB
            If vector(iA) < vector(iB) Then
                VAux(i) = vector(iA)
                iA = iA + 1
            Else
                VAux(i) = vector(iB)
                iB = iB + 1
            End If
            i = i + 1
        End While
        'Completar VAux() con el remanente de A() o B(), el que corresponda!
        If iA > dA Then
            'Completar VAux() con el remanente de B()
            While i <= UBound(VAux)
                VAux(i) = vector(iB)
                iB = iB + 1
                i = i + 1
            End While
        Else
            'Completar VAux() con el remanente de A()
            While i <= UBound(VAux)
                VAux(i) = vector(iA)
                iA = iA + 1
                i = i + 1
            End While
        End If
        'Volcar en V() el vector ordenado VAux()
        i = 0
        While i <= UBound(VAux)
            vector(i + iInicio) = VAux(i)
            i = i + 1
        End While
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '8 QuickSort: Pemite ordenar rapido mientras mas elementos, y mas desordenado esta.
    'La formula es mas o menos Log en base 2 de "N"
    'Se elije un elemento (pivote) como el del medio y se va comparando con el resto de los numeros ordenando
    'a los mas chicos de un lado y los mas grandes del otro, hasta quedar el valor vacio del medio donde se termina
    'metiendo. Este metodo es recursivo, es decir, que se llama a si mismo las veces necesarias.
    '------------------------------------------------------------------------------------------------------------
    Private Sub MetodoQuicksort()
        Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
        Cursor = Cursors.WaitCursor
        If chkGraficos.Checked Then
            InicioDeBotones()
        End If

        QuickSort(V, 0, UltimaPosicion)
        MetodoQuicksort_Datos()
        FinalDeBotones()
        Cursor = Cursors.Default
        Me.Text = "Métodos de Ordenamiento"
    End Sub

    'Grafico
    Private Sub QuickSort(Vector() As Long, Li As Integer, Ld As Integer)
        Dim Pi, Pd, pivot As Integer
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        cAsignaciones = cAsignaciones + 3
        Pi = Li
        Pd = Ld
        pivot = Vector(Li)
        cCondicionales = cCondicionales + 1
        While Pi < Pd
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Yellow, Pi)
                Threading.Thread.Sleep(Demora)
            End If
            While Vector(Pd) >= pivot And Pi < Pd
                cCondicionales = cCondicionales + 1
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Blue, Pd)
                End If
                cAsignaciones = cAsignaciones + 1
                Pd = Pd - 1
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Yellow, Pd)
                    Threading.Thread.Sleep(Demora)
                End If
            End While
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Yellow, Pi)
                Threading.Thread.Sleep(Demora)
            End If
            cAsignaciones = cAsignaciones + 1
            Vector(Pi) = Vector(Pd)
            cCondicionales = cCondicionales + 1
            While Vector(Pi) < pivot And Pi < Pd
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Blue, Pi)
                End If
                cAsignaciones = cAsignaciones + 1
                Pi = Pi + 1
                If chkGraficos.Checked Then
                    GraficarBarra(Brushes.Yellow, Pi)
                    Threading.Thread.Sleep(Demora)
                End If
            End While
            cAsignaciones = cAsignaciones + 1
            Vector(Pd) = Vector(Pi)
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Orange, Pi)
                GraficarBarra(Brushes.Orange, Pd)
                Threading.Thread.Sleep(Demora)
            End If
        End While
        If chkGraficos.Checked Then
            GraficarBarra(Brushes.Green, Pi)
        End If
        cAsignaciones = cAsignaciones + 1
        Vector(Pi) = pivot
        cCondicionales = cCondicionales + 1
        If (Pd - 1) > Li Then
            QuickSort(Vector, Li, Pd - 1)
        Else
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Green, Li)
            End If
        End If
        cCondicionales = cCondicionales + 1
        If (Pi + 1) < Ld Then
            QuickSort(Vector, Pi + 1, Ld)
        Else
            If chkGraficos.Checked Then
                GraficarBarra(Brushes.Green, Ld)
            End If
        End If
        lQuick.Items.Clear()
        lQuick.Items.Add("C: " & cCondicionales)
        lQuick.Items.Add("A: " & cAsignaciones)
    End Sub

    'Datos
    Private Sub MetodoQuicksort_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan

        'Tomar tiempo actual
        TiempoInicial = Now
        QuickSort_Datos(VD, 0, UltimaPosicion)

        'Tomar tiempo final
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lQuick.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
        GraficarVector(Brushes.Green)
    End Sub

    Private Sub QuickSort_Datos(Vector As Long(), Li As Integer, Ld As Integer)
        Dim Pi, Pd, pivot As Integer

        Pi = Li
        Pd = Ld
        pivot = Vector(Li)

        While Pi < Pd
            While Vector(Pd) >= pivot And Pi < Pd
                Pd = Pd - 1
            End While
            Vector(Pi) = Vector(Pd)
            While Vector(Pi) < pivot And Pi < Pd
                Pi = Pi + 1
            End While
            Vector(Pd) = Vector(Pi)
        End While
        Vector(Pi) = pivot
        If (Pd - 1) > Li Then
            QuickSort_Datos(Vector, Li, Pd - 1)
        End If
        If (Pi + 1) < Ld Then
            QuickSort_Datos(Vector, Pi + 1, Ld)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    'Botones de comando p/ Crear, ver y recargar vector
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdCrearVector_Click(sender As Object, e As EventArgs) Handles cmdCrearVector.Click
        Dim R As New Random
        Dim I, C, K, AUX As Long
        Dim NUMERO As Long
        If Val(txtElementos.Text) > 1 Then
            'Asignar tamaño de vector y redimensionar"
            UltimaPosicion = CLng(Math.Round(Val(txtElementos.Text) - 1))
            ReDim VECTOR_INICIAL(UltimaPosicion)

            '1 Cargar el vector con los datos "ordenados"
            I = 0
            Do While I <= UltimaPosicion
                NUMERO = NUMERO + 1
                VECTOR_INICIAL(I) = NUMERO
                I = I + 1
            Loop
            'Asignamos el numero más grande a la variable MaxValor para el calculo de la altura del grafico
            MaxValor = NUMERO

            Dim Repetidos As Long = tbRepetidos.Value
            '2 Si se permite repetir numeros, el rango variará entre 1 y la ultimaposicion ajustando la variabilidad de los numeros random
            If chkRepetidos.Checked Then
                For I = 1 To UltimaPosicion - 1 Step Repetidos
                    VECTOR_INICIAL(R.Next(1, UltimaPosicion - 1)) = VECTOR_INICIAL(I - 1)
                Next
            End If

            '3 Desordenar el vector
            K = 0
            While K < UltimaPosicion * (NivelDesorden / 15)
                I = R.Next(UltimaPosicion + 1)
                C = R.Next(UltimaPosicion + 1)
                AUX = VECTOR_INICIAL(I)
                VECTOR_INICIAL(I) = VECTOR_INICIAL(C)
                VECTOR_INICIAL(C) = AUX
                K = K + 1
            End While

            '4 Clonar el vector original en el vector que vamos a modificar, en el que usamos para las mediciones y graficamos
            VD = VECTOR_INICIAL.Clone
            V = VECTOR_INICIAL.Clone
            GraficarVector(Brushes.Blue)
        Else
            MessageBox.Show("Primero necesita cargar un número de elementos," + vbLf + "y que este sea mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cmdVerVector_Click(sender As Object, e As EventArgs) Handles cmdVerVector.Click
        Dim OrdenadoOno As Boolean
        GRILLA.Rows.Clear()
        If V IsNot Nothing Then
            Dim i As Long = 0

            For i = 0 To UltimaPosicion
                OrdenadoOno = False
                If chkGraficos.Checked Then
                    GRILLA.Rows.Add(V(i))
                Else
                    GRILLA.Rows.Add(VD(i))
                End If
            Next

            For i = 0 To UltimaPosicion - 1
                If chkGraficos.Checked Then
                    If V(i) <= V(i + 1) Then
                        OrdenadoOno = True
                    Else
                        OrdenadoOno = False
                        Exit For
                    End If
                Else
                    If VD(i) <= VD(i + 1) Then
                        OrdenadoOno = True
                    Else
                        OrdenadoOno = False
                        Exit For
                    End If
                End If
            Next
            If OrdenadoOno = True Then
                lblOrdenado.Text = "Ordenado!"
            Else
                lblOrdenado.Text = "Desordenado!"
            End If
            lblOrdenado.Visible = True
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub cmdRecargarVector_Click(sender As Object, e As EventArgs) Handles cmdRecargarVector.Click
        If V IsNot Nothing Then
            VD = VECTOR_INICIAL.Clone
            V = VECTOR_INICIAL.Clone
            GraficarVector(Brushes.Blue)
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    'Botones de Ordenamiento
    '------------------------------------------------------------------------------------------------------------
    '1 Burbuja Normal
    '------------------------------------------------------------------------------------------------------------

    Private Sub cmdNormal_Click(sender As Object, e As EventArgs) Handles cmdNormal.Click

        If MaxValor > 0 Then
            THREAD = New Threading.Thread(AddressOf BurbujaNormal)
            THREAD.Start()
            '        MessageBox.Show("El vector está completamente ordenado!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '2 Burbuja c/ Bandera
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdBandera_Click(sender As Object, e As EventArgs) Handles cmdBandera.Click
        If MaxValor > 0 Then
            THREAD = New Threading.Thread(AddressOf BurbujaBandera)
            THREAD.Start()
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '3 Burbuja Optimizada
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdOptimizada_Click(sender As Object, e As EventArgs) Handles cmdOptimizada.Click
        If MaxValor > 0 Then
            THREAD = New Threading.Thread(AddressOf BurbujaOptimizada)
            THREAD.Start()
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '4 Burbuja Bidireccional
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdBidireccional_Click(sender As Object, e As EventArgs) Handles cmdBidireccional.Click
        If MaxValor > 0 Then
            THREAD = New Threading.Thread(AddressOf BurbujaBidireccional)
            THREAD.Start()
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '5 Selección Directa
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdDirecta_Click(sender As Object, e As EventArgs) Handles cmdDirecta.Click
        If MaxValor > 0 Then
            THREAD = New Threading.Thread(AddressOf SeleccionDirecta)
            THREAD.Start()
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '6 Burbuja por Inserción
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdInsercion_Click(sender As Object, e As EventArgs) Handles cmdInsercion.Click
        If MaxValor > 0 Then
            THREAD = New Threading.Thread(AddressOf BurbujaConInsercion)
            THREAD.Start()
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '7 Merge Sort
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdMergeSort_Click(sender As Object, e As EventArgs) Handles cmdMergeSort.Click
        If MaxValor > 0 Then
            THREAD = New Threading.Thread(AddressOf MergeSort)
            THREAD.Start()
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '8 Quick Sort
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdQuickSort_Click(sender As Object, e As EventArgs) Handles cmdQuickSort.Click
        If MaxValor > 0 Then
            THREAD = New Threading.Thread(AddressOf MetodoQuicksort)
            THREAD.Start()
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    'Controles tipo Trackbar
    '------------------------------------------------------------------------------------------------------------
    Public Sub tDesordenar_Scroll(sender As Object, e As EventArgs) Handles tDesordenar.Scroll
        NivelDesorden = tDesordenar.Value
    End Sub
    Public Sub tVelocidad_Scroll(sender As Object, e As EventArgs) Handles tVelocidad.Scroll
        Demora = tVelocidad.Value
    End Sub
    Private Sub tVelocidad_MouseHover(sender As Object, e As EventArgs) Handles tVelocidad.MouseHover
        EventoDeMouseHover()
    End Sub
    Private Sub tVelocidad_MouseLeave(sender As Object, e As EventArgs) Handles tVelocidad.MouseLeave
        EventoDeMouseLeave()
    End Sub
    '------------------------------------------------------------------------------------------------------------
    'Controles tipo Checkbox
    '------------------------------------------------------------------------------------------------------------
    Private Sub chkMonitoreo_CheckedChanged(sender As Object, e As EventArgs) Handles chkMonitoreo.CheckedChanged
        If chkMonitoreo.Checked Then
            gpMediciones.Enabled = True
            Size = New Size(Size.Width, 752)
        Else
            gpMediciones.Enabled = False
            Size = New Size(Size.Width, 592)
        End If
    End Sub
    Public Sub chkGraficos_CheckedChanged(sender As Object, e As EventArgs) Handles chkGraficos.CheckedChanged
        If chkGraficos.Checked Then
            GraficoOno = True
        Else
            GraficoOno = False
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------------
    'Evento Maximizar/Minimizar p/ redimensionar controles
    '------------------------------------------------------------------------------------------------------------
    Private Sub Principal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Maximizar.ResizeAllControls(Me)
        picGrafico.Size = New Size(1404, 629)
    End Sub

    '------------------------------------------------------------------------------------------------------------
    'Botonoes de control de gráfico
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdPlay_Click(sender As Object, e As EventArgs) Handles cmdPlay.Click
        If THREAD IsNot Nothing Then
            Select Case THREAD.ThreadState
                Case Threading.ThreadState.Running
                    THREAD.Suspend()
                    cmdPlay.BackColor = Color.Gray
                    Cursor = Cursors.Default
                Case Threading.ThreadState.Suspended
                    THREAD.Resume()
                    cmdPlay.BackColor = Color.Green
                    Cursor = Cursors.WaitCursor
                Case Else
                    THREAD.Suspend()
                    cmdPlay.BackColor = Color.Gray
                    Cursor = Cursors.Default
            End Select
        End If
    End Sub

    Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
        'En caso de que la gráfica tarde mucho tiempo cerrar el hilo y recargar el vector original
        THREAD.Suspend()
        If MessageBox.Show("Cancelar ordenamiento?" + vbLf + "Al hacerlo se cargará el vector original nuevamente", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            THREAD.Resume()
            Cursor = Cursors.WaitCursor
        Else
            THREAD.Resume()
            THREAD.Abort()
            Cursor = Cursors.Default
            V = VECTOR_INICIAL.Clone
            GraficarVector(Brushes.Blue)
            FinalDeBotones()
        End If
    End Sub
    Private Sub cmdPlay_MouseHover(sender As Object, e As EventArgs) Handles cmdPlay.MouseHover
        EventoDeMouseHover()
    End Sub

    Private Sub cmdStop_MouseHover(sender As Object, e As EventArgs) Handles cmdStop.MouseHover
        EventoDeMouseHover()
    End Sub
    Private Sub InicioDeBotones()
        cmdPlay.Visible = True
        cmdStop.Visible = True
        cmdPlay.Text = ">"
        cmdPlay.BackColor = Color.Green
    End Sub
    Private Sub FinalDeBotones()
        cmdPlay.Visible = False
        cmdStop.Visible = False
    End Sub
    '------------------------------------------------------------------------------------------------------------
    'Procedimientos de gráfico
    '------------------------------------------------------------------------------------------------------------
    Public Sub GraficarVector(ByVal Pintar As Brush)
        'Limpiar el Picturebox
        Lienzo.Clear(picGrafico.BackColor)

        'Llamar al metodo GraficarBarra y hacer recorrido para pintar todo el vector
        Dim i As Long = 0
        Do While i <= UltimaPosicion
            GraficarBarra(Pintar, i)
            If UltimaPosicion <= picGrafico.Width Then
                i = i + 1
            Else
                i = CLng(Math.Round(i + (UltimaPosicion / picGrafico.Width)))
            End If
        Loop
    End Sub

    Public Sub GraficarBarra(ByVal ColorRelleno As Brush, ByVal Posic As Long)
        Dim fph As Single, fpv As Single
        Dim x1 As Integer, y1 As Integer, ancho As Single, alto As Single, barra As Single

        'Calcular proporciones y posiciones
        fph = picGrafico.Width / (UltimaPosicion + 1)

        fpv = picGrafico.Height / MaxValor

        x1 = Posic * fph
        '        If GraficoOno = True Then
        y1 = picGrafico.Height - (V(Posic) * fpv)
        alto = V(Posic) * fpv
        '       Else
        '      y1 = picGrafico.Height - (VD(Posic) * fpv)
        '     alto = VD(Posic) * fpv
        '    End If
        ancho = fph
        ' Generar barras separadas hasta los 100 elementos para ver mejor el movimiento de la grafica
        If UltimaPosicion > 99 Then
            barra = fph
        Else
            barra = fph - (25 * fph / 100)
        End If

        'Trazar
        Lienzo.FillRectangle(Brushes.White, x1, 0, IIf(ancho < 1, 1, ancho), picGrafico.Height)
        Lienzo.FillRectangle(ColorRelleno, x1, y1, IIf(barra < 1, 1, barra), alto)
    End Sub
    Private Sub GRILLA_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GRILLA.CellValueChanged
        'Cuando se dispare el evento de cambio de valor en las celdas de la grilla se hace una pequeña comprobación p/ si
        'los valores aun no fueron cargados

        If e.RowIndex = -1 Then Exit Sub

        'Guardar la posición y valor de la celda
        Cambio = GRILLA.CurrentRow.Cells(0).Value
        Lugar = GRILLA.CurrentRow.Index

        'Recorrer vector y cambiar valor
        For i = 0 To UltimaPosicion - 1
            If V(i) <> GRILLA.CurrentRow.Cells(0).Value Then
                V(Lugar) = Cambio
                VD(Lugar) = Cambio
            End If
        Next
    End Sub

    Private Sub txtElementos_TextChanged(sender As Object, e As EventArgs) Handles txtElementos.TextChanged
    End Sub

    Private Sub txtElementos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtElementos.KeyPress
        'Deshabilitar caracteres
        If (IsNumeric(e.KeyChar) Or e.KeyChar = vbBack) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub tbRepetidos_Scroll(sender As Object, e As EventArgs) Handles tbRepetidos.Scroll
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmdNormal_Click(sender, e)
        THREAD.Join()
        V = VECTOR_INICIAL.Clone
        cmdBandera_Click(sender, e)
        THREAD.Join()
        V = VECTOR_INICIAL.Clone
        cmdOptimizada_Click(sender, e)
        THREAD.Join()
        V = VECTOR_INICIAL.Clone
        cmdBidireccional_Click(sender, e)
        THREAD.Join()
        V = VECTOR_INICIAL.Clone
        cmdDirecta_Click(sender, e)
        THREAD.Join()
        V = VECTOR_INICIAL.Clone
        cmdInsercion_Click(sender, e)
        THREAD.Join()
        V = VECTOR_INICIAL.Clone
        cmdMergeSort_Click(sender, e)
        THREAD.Join()
        V = VECTOR_INICIAL.Clone
        cmdQuickSort_Click(sender, e)
        THREAD.Join()
    End Sub

    Private Sub EventoDeMouseHover()
        If THREAD IsNot Nothing Then
            If THREAD.IsAlive Then
                Select Case THREAD.ThreadState
                    Case Threading.ThreadState.Running
                        Cursor = Cursors.Default
                    Case Threading.ThreadState.Suspended
                        Cursor = Cursors.Default
                    Case Else
                        Cursor = Cursors.Default
                End Select
            Else
                Cursor = Cursors.Default
            End If
        End If
    End Sub
    Private Sub EventoDeMouseLeave()
        If THREAD IsNot Nothing Then
            If THREAD.IsAlive Then
                Select Case THREAD.ThreadState
                    Case Threading.ThreadState.Running
                        Cursor = Cursors.WaitCursor
                    Case Threading.ThreadState.Suspended
                        Cursor = Cursors.Default
                    Case Else
                        Cursor = Cursors.WaitCursor
                End Select
            Else
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub cmdPlay_MouseLeave(sender As Object, e As EventArgs) Handles cmdPlay.MouseLeave
        EventoDeMouseLeave()
    End Sub

    Private Sub cmdStop_MouseLeave(sender As Object, e As EventArgs) Handles cmdStop.MouseLeave
        EventoDeMouseLeave()
    End Sub

End Class
