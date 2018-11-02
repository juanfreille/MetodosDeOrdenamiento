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
        Limite = UltimaPosicion
        While Limite > 0
            i = 0
            While i < Limite
                GraficarBarra(Brushes.Yellow, i)
                GraficarBarra(Brushes.Yellow, i + 1)
                Threading.Thread.Sleep(Demora)
                If V(i) > V(i + 1) Then
                    CambiarElementos(V, i, i + 1)
                    GraficarBarra(Brushes.Orange, i)
                    GraficarBarra(Brushes.Orange, i + 1)
                    Threading.Thread.Sleep(Demora * 2)
                End If
                GraficarBarra(Brushes.Blue, i)
                GraficarBarra(Brushes.Blue, i + 1)
                i = i + 1
            End While
            GraficarBarra(Brushes.Green, Limite)
            Limite = Limite - 1
        End While
        GraficarBarra(Brushes.Green, 0)
        BurbujaNormal_Datos()
        FinalDeBotones()
    End Sub

    'Datos
    Public Sub BurbujaNormal_Datos()
        'Tomar tiempo actual
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim i As Long, Limite As Long
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        TiempoInicial = Now
        cAsignaciones = cAsignaciones + 1
        Limite = UltimaPosicion
        cCondicionales = cCondicionales + 1
        While Limite > 0
            cAsignaciones = cAsignaciones + 1
            i = 0
            cCondicionales = cCondicionales + 1
            While i < Limite
                cCondicionales = cCondicionales + 1
                If VD(i) > VD(i + 1) Then
                    cAsignaciones = cAsignaciones + 3
                    CambiarElementos(VD, i, i + 1)
                End If
                cAsignaciones = cAsignaciones + 1
                i = i + 1
            End While
            cAsignaciones = cAsignaciones + 1
            Limite = Limite - 1
        End While

        'Tomar tiempo final
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lBurbuja.Items.Clear()
        lBurbuja.Items.Add("C: " & cCondicionales)
        lBurbuja.Items.Add("A: " & cAsignaciones)
        lBurbuja.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '2 Burbuja Con Bandera (Salir si ya esta ordenado)
    '------------------------------------------------------------------------------------------------------------
    'Grafico
    Private Sub BurbujaBandera()
        Dim i As Long = 0
        Dim Limite As Long
        Dim HuboCambio As Boolean

        HuboCambio = True
        Limite = UltimaPosicion
        While Limite > 0 And HuboCambio
            '            GraficarBarra(Brushes.Red, Limite)
            HuboCambio = False
            i = 0
            While i < Limite
                GraficarBarra(Brushes.Yellow, i)
                GraficarBarra(Brushes.Yellow, i + 1)
                Threading.Thread.Sleep(Demora * 2)
                If V(i) > V(i + 1) Then
                    HuboCambio = True
                    CambiarElementos(V, i, (i + 1))
                    GraficarBarra(Brushes.Orange, i)
                    GraficarBarra(Brushes.Orange, i + 1)
                    Threading.Thread.Sleep(Demora * 2)
                End If
                GraficarBarra(Brushes.Blue, i)
                Threading.Thread.Sleep(Demora * 2)
                i = i + 1
            End While
            GraficarBarra(Brushes.Green, Limite)
            Limite = Limite - 1
        End While

        For i = 0 To Limite
            GraficarBarra(Brushes.Green, i)
        Next

        BurbujaBandera_Datos()
        FinalDeBotones()
    End Sub

    'Datos
    Private Sub BurbujaBandera_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim i As Long = 0
        Dim Limite As Long
        Dim HuboCambio As Boolean
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        TiempoInicial = Now
        cAsignaciones = cAsignaciones + 1
        HuboCambio = True
        cAsignaciones = cAsignaciones + 1
        Limite = UltimaPosicion
        cCondicionales = cCondicionales + 3
        While Limite > 0 And HuboCambio
            cAsignaciones = cAsignaciones + 1
            HuboCambio = False
            cAsignaciones = cAsignaciones + 1
            i = 0
            cCondicionales = cCondicionales + 1
            While i < Limite
                cCondicionales = cCondicionales + 1
                If VD(i) > VD(i + 1) Then
                    cAsignaciones = cAsignaciones + 1
                    HuboCambio = True
                    cAsignaciones = cAsignaciones + 3
                    CambiarElementos(VD, i, (i + 1))
                End If
                cAsignaciones = cAsignaciones + 1
                i = i + 1
            End While
            cAsignaciones = cAsignaciones + 1
            Limite = Limite - 1
        End While
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lBandera.Items.Clear()
        lBandera.Items.Add("C: " & cCondicionales)
        lBandera.Items.Add("A: " & cAsignaciones)
        lBandera.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '3 Burbuja Optimizada (Posicion Ultimo Cambio)
    '------------------------------------------------------------------------------------------------------------
    'Grafico
    Private Sub BurbujaOptimizada()
        Dim i As Long = 0
        Dim PUC As Long
        Dim Limite As Long = UltimaPosicion

        While Limite > 0
            i = 0
            PUC = 0
            While i < Limite
                GraficarBarra(Brushes.Yellow, i)
                GraficarBarra(Brushes.Yellow, i + 1)
                Threading.Thread.Sleep(Demora)
                If V(i) > V(i + 1) Then
                    CambiarElementos(V, i, (i + 1))
                    PUC = i
                    GraficarBarra(Brushes.Orange, i)
                    GraficarBarra(Brushes.Orange, i + 1)
                    Threading.Thread.Sleep(Demora * 2)
                End If
                GraficarBarra(Brushes.Blue, i)
                GraficarBarra(Brushes.Blue, i + 1)
                i = i + 1
            End While
            GraficarBarra(Brushes.Green, Limite)
            Limite = PUC
        End While
        GraficarBarra(Brushes.Green, 0)

        BurbujaOptimizada_Datos()
        FinalDeBotones()
    End Sub

    'Datos
    Private Sub BurbujaOptimizada_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim i As Long = 0
        Dim PUC As Long
        Dim Limite As Long
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        TiempoInicial = Now
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
                cCondicionales = cCondicionales + 1
                If VD(i) > VD(i + 1) Then
                    cAsignaciones = cAsignaciones + 4
                    CambiarElementos(VD, i, (i + 1))
                    PUC = i
                End If
                cAsignaciones = cAsignaciones + 1
                i = i + 1
            End While
            cAsignaciones = cAsignaciones + 1
            Limite = PUC
        End While
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lOptimizada.Items.Clear()
        lOptimizada.Items.Add("C: " & cCondicionales)
        lOptimizada.Items.Add("A: " & cAsignaciones)
        lOptimizada.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
    End Sub
    '------------------------------------------------------------------------------------------------------------
    '4 Burbuja Bidireccional
    '------------------------------------------------------------------------------------------------------------
    'Grafico

    Private Sub BurbujaBidireccional()
        Dim i As Integer = 0
        Dim num As Integer = 0
        Do
            num = 0
            While Not i = V.Length - 1
                If V(i) > V(i + 1) Then
                    CambiarElementos(V, i, i + 1)
                    num += 1
                End If
                i += 1
            End While
            If num = 0 Then
                Exit Do
            End If
            While Not i = 0
                If V(i) < V(i - 1) Then
                    CambiarElementos(V, i, i - 1)
                    num += 1
                End If
                i -= 1
            End While
        Loop Until num = 0

        BurbujaBidireccional_Datos()
        FinalDeBotones()
    End Sub

    'Datos
    Private Sub BurbujaBidireccional_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim posic As Long = 0
        Dim posicionUltimoElemento As Long = UltimaPosicion
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0
        Dim num As Long
        Dim num5 As Long = posic
        Dim num2 As Long = posic

        TiempoInicial = Now
        cAsignaciones = cAsignaciones + 1
        posicionUltimoElemento = UltimaPosicion
        cCondicionales = cCondicionales + 1

        While posic < posicionUltimoElemento
            cAsignaciones = cAsignaciones + 2
            num5 = posic
            num2 = posic
            cCondicionales = cCondicionales + 1
            While num2 < posicionUltimoElemento
                cCondicionales = cCondicionales + 1
                If VD(num2) > VD(num2 + 1) Then
                    cAsignaciones = cAsignaciones + 4
                    num = VD(num2)
                    VD(num2) = VD(num2 + 1)
                    VD(num2 + 1) = num
                    num5 = num2
                End If
                cAsignaciones = cAsignaciones + 1
                num2 = num2 + 1
            End While
            cAsignaciones = cAsignaciones + 3
            posicionUltimoElemento = num5
            num5 = posicionUltimoElemento
            num2 = posicionUltimoElemento
            While num2 > posic
                cCondicionales = cCondicionales + 1
                If VD(num2) < VD(num2 - 1) Then
                    cAsignaciones = cAsignaciones + 4
                    num = VD(num2)
                    VD(num2) = VD(num2 - 1)
                    VD(num2 - 1) = num
                    num5 = num2
                End If
                cAsignaciones = cAsignaciones + 1
                num2 = num2 - 1
            End While
            cAsignaciones = cAsignaciones + 1
            posic = num5
        End While

        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lBidireccional.Items.Clear()
        lBidireccional.Items.Add("C: " & cCondicionales)
        lBidireccional.Items.Add("A: " & cAsignaciones)
        lBidireccional.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
    End Sub


    '------------------------------------------------------------------------------------------------------------
    '5 Selección Directa (Termina cuando la variable base llega al ultimo). Es un metodo no adaptativo, no es 
    'capaz de mejorar su desempeño. Es el metodo que menos intercambios realiza.
    '------------------------------------------------------------------------------------------------------------
    'Grafico
    Private Sub SeleccionDirecta()
        Dim Base As Long = 0
        Dim Menor As Long = 0
        Dim i As Long = 0

        While Base < UltimaPosicion
            Menor = Base
            i = Base + 1
            GraficarBarra(Brushes.Blue, i)
            While i <= UltimaPosicion
                GraficarBarra(Brushes.Blue, Menor)
                If V(i) < V(Menor) Then
                    Menor = i
                    GraficarBarra(Brushes.Green, Menor)
                End If
                GraficarBarra(Brushes.Orange, Menor)
                GraficarBarra(Brushes.Yellow, i)
                Threading.Thread.Sleep(Demora * 2)
                i = i + 1
                GraficarBarra(Brushes.Blue, i - 1)
            End While
            CambiarElementos(V, Base, Menor)
            GraficarBarra(Brushes.Blue, Menor)
            GraficarBarra(Brushes.Green, Base)
            Threading.Thread.Sleep(Demora)
            Base = Base + 1
        End While
        GraficarBarra(Brushes.Green, i - 1)
        SeleccionDirecta_Datos()
        FinalDeBotones()
    End Sub

    'Datos
    Private Sub SeleccionDirecta_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim Base As Long
        Dim Menor As Long
        Dim i As Long = 0
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        TiempoInicial = Now
        cAsignaciones = cAsignaciones + 1
        Base = 0
        cCondicionales = cCondicionales + 1

        While Base < UltimaPosicion
            cAsignaciones = cAsignaciones + 2
            Menor = Base
            i = Base + 1
            cCondicionales = cCondicionales + 1
            While i <= UltimaPosicion
                cCondicionales = cCondicionales + 1
                If VD(i) < VD(Menor) Then
                    cAsignaciones = cAsignaciones + 1
                    Menor = i
                End If
                cAsignaciones = cAsignaciones + 1
                i = i + 1
            End While
            cAsignaciones = cAsignaciones + 4
            CambiarElementos(VD, Base, Menor)
            Base = Base + 1
        End While

        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lDirecta.Items.Clear()
        lDirecta.Items.Add("C: " & cCondicionales)
        lDirecta.Items.Add("A: " & cAsignaciones)
        lDirecta.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
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

        Frontera = 1 'Segundo elemento, porque asumimos que el primer elemento esta ordenado
        While Frontera <= UltimaPosicion
            aux = V(Frontera)
            i = Frontera - 1
            While i >= 0 AndAlso V(i) > aux
                GraficarBarra(Brushes.Blue, i)
                GraficarBarra(Brushes.Green, Frontera)
                V(i + 1) = V(i)
                GraficarBarra(Brushes.Orange, i)
                Threading.Thread.Sleep(Demora * 2)
                GraficarBarra(Brushes.Blue, i + 1)
                Threading.Thread.Sleep(Demora * 2)
                i = i - 1
            End While
            GraficarBarra(Brushes.Green, Frontera)
            GraficarBarra(Brushes.Blue, i + 1)
            V(i + 1) = aux
            GraficarBarra(Brushes.Blue, i + 1)
            Threading.Thread.Sleep(Demora * 10)
            GraficarBarra(Brushes.Green, Frontera)
            Threading.Thread.Sleep(Demora * 2)
            Frontera = Frontera + 1
        End While
        GraficarBarra(Brushes.Green, 0)

        For i = 0 To UltimaPosicion
            GraficarBarra(Brushes.Orange, i)
            Threading.Thread.Sleep(Demora * 5)
            GraficarBarra(Brushes.Green, i)
            Threading.Thread.Sleep(Demora * 10)
        Next

        BurbujaConInsercion_Datos()
        FinalDeBotones()
    End Sub

    'Datos
    Private Sub BurbujaConInsercion_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim aux = 0
        Dim Frontera
        Dim i = 0
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        TiempoInicial = Now
        cAsignaciones = cAsignaciones + 1
        Frontera = 1
        cCondicionales = cCondicionales + 1

        While Frontera <= UltimaPosicion
            cAsignaciones = cAsignaciones + 2
            aux = VD(Frontera)
            i = Frontera - 1
            cCondicionales = cCondicionales + 1
            While i >= 0 AndAlso VD(i) > aux
                cAsignaciones = cAsignaciones + 2
                VD(i + 1) = VD(i)
                i = i - 1
            End While
            cAsignaciones = cAsignaciones + 2
            VD(i + 1) = aux
            Frontera = Frontera + 1
        End While
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lInsercion.Items.Clear()
        lInsercion.Items.Add("C: " & cCondicionales)
        lInsercion.Items.Add("A: " & cAsignaciones)
        lInsercion.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
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
                MezclarVector(IzqA, DerA, IzqB, DerB, V)
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

        MergeSort_Datos()
        FinalDeBotones()
    End Sub

    'Datos
    Sub MergeSort_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan
        Dim IzqA, DerA, IzqB, DerB As Integer
        Dim AnchoSeccion As Integer
        Dim cAsignaciones As Integer = 0
        Dim cCondicionales As Integer = 0

        TiempoInicial = Now
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
                MezclarVector(IzqA, DerA, IzqB, DerB, VD)
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

        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lMerge.Items.Clear()
        lMerge.Items.Add("C: " & cCondicionales)
        lMerge.Items.Add("A: " & cAsignaciones)
        lMerge.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
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
        QuickSort(V, 0, UltimaPosicion)
        FinalDeBotones()
        MetodoQuicksort_Datos()
    End Sub

    'Grafico
    Private Sub QuickSort(Vector() As Long, Li As Integer, Ld As Integer)
        Dim Pi, Pd, pivot As Integer
        Pi = Li
        Pd = Ld
        pivot = Vector(Li)


        While Pi < Pd
            GraficarBarra(Brushes.Yellow, Pi)
            Threading.Thread.Sleep(Demora)
            While Vector(Pd) >= pivot And Pi < Pd
                GraficarBarra(Brushes.Blue, Pd)
                Pd = Pd - 1
                GraficarBarra(Brushes.Yellow, Pd)
                Threading.Thread.Sleep(Demora)
            End While

            GraficarBarra(Brushes.Yellow, Pi)
            Threading.Thread.Sleep(Demora)
            Vector(Pi) = Vector(Pd)
            While Vector(Pi) < pivot And Pi < Pd
                GraficarBarra(Brushes.Blue, Pi)
                Pi = Pi + 1

                GraficarBarra(Brushes.Yellow, Pi)
                Threading.Thread.Sleep(Demora)
            End While
            Vector(Pd) = Vector(Pi)

            GraficarBarra(Brushes.Orange, Pi)
            GraficarBarra(Brushes.Orange, Pd)
            Threading.Thread.Sleep(Demora)
        End While

        GraficarBarra(System.Drawing.Brushes.Green, Pi)
        Vector(Pi) = pivot
        If (Pd - 1) > Li Then
            QuickSort(Vector, Li, Pd - 1)
        Else

            GraficarBarra(Brushes.Green, Li)

        End If
        If (Pi + 1) < Ld Then
            QuickSort(Vector, Pi + 1, Ld)
        Else
            GraficarBarra(Brushes.Green, Ld)
        End If
    End Sub

    'Datos
    Private Sub MetodoQuicksort_Datos()
        Dim TiempoInicial As DateTime
        Dim TiempoFinal As DateTime
        Dim TiempoDeProceso As TimeSpan

        TiempoInicial = Now
        QuickSort_Datos(VD, 0, UltimaPosicion, 0, 0)
        TiempoFinal = Now
        TiempoDeProceso = TiempoFinal.Subtract(TiempoInicial)
        lQuick.Items.Add("T: " & TiempoDeProceso.TotalSeconds.ToString("0.0000"))
    End Sub

    Private Sub QuickSort_Datos(Vector As Long(), Li As Integer, Ld As Integer, cAsignaciones As Integer, cCondicionales As Integer)
        Dim Pi, Pd, pivot As Integer

        cAsignaciones = cAsignaciones + 3
        Pi = Li
        Pd = Ld
        pivot = Vector(Li)
        cCondicionales = cCondicionales + 1

        While Pi < Pd
            cCondicionales = cCondicionales + 1
            While Vector(Pd) >= pivot And Pi < Pd
                cAsignaciones = cAsignaciones + 1
                Pd = Pd - 1
            End While
            cAsignaciones = cAsignaciones + 1
            Vector(Pi) = Vector(Pd)
            cCondicionales = cCondicionales + 1
            While Vector(Pi) < pivot And Pi < Pd
                cAsignaciones = cAsignaciones + 1
                Pi = Pi + 1
            End While
            cAsignaciones = cAsignaciones + 1
            Vector(Pd) = Vector(Pi)
        End While
        cAsignaciones = cAsignaciones + 1
        Vector(Pi) = pivot
        cCondicionales = cCondicionales + 1
        If (Pd - 1) > Li Then
            QuickSort_Datos(Vector, Li, Pd - 1, cAsignaciones, cCondicionales)
        End If
        cCondicionales = cCondicionales + 1
        If (Pi + 1) < Ld Then
            QuickSort_Datos(Vector, Pi + 1, Ld, cAsignaciones, cCondicionales)
        End If
        lQuick.Items.Clear()
        lQuick.Items.Add("C: " & cCondicionales)
        lQuick.Items.Add("A: " & cAsignaciones)
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
            Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
            Cursor = Cursors.WaitCursor
            If chkGraficos.Checked = True Then
                THREAD = New Threading.Thread(AddressOf BurbujaNormal)
                THREAD.Start()
                InicioDeBotones()
            Else
                THREAD = New Threading.Thread(AddressOf BurbujaNormal_Datos)
                THREAD.Start()
                Repintar(VD)
            End If
            Cursor = Cursors.Default
            Me.Text = "Métodos de Ordenamiento"
            MessageBox.Show("El vector está completamente ordenado!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    '------------------------------------------------------------------------------------------------------------
    '2 Burbuja c/ Bandera
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdBandera_Click(sender As Object, e As EventArgs) Handles cmdBandera.Click
        If MaxValor > 0 Then
            Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
            Cursor = Cursors.WaitCursor
            If chkGraficos.Checked = True Then
                THREAD = New Threading.Thread(AddressOf BurbujaBandera)
                THREAD.Start()
                InicioDeBotones()
            Else
                THREAD = New Threading.Thread(AddressOf BurbujaBandera_Datos)
                THREAD.Start()
                Repintar(VD)
            End If
            Me.Text = "Métodos de Ordenamiento"
            Cursor = Cursors.Default
            MessageBox.Show("El vector está completamente ordenado!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '3 Burbuja Optimizada
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdOptimizada_Click(sender As Object, e As EventArgs) Handles cmdOptimizada.Click
        If MaxValor > 0 Then
            Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
            Cursor = Cursors.WaitCursor
            If chkGraficos.Checked = True Then
                THREAD = New Threading.Thread(AddressOf BurbujaOptimizada)
                THREAD.Start()
                InicioDeBotones()
            Else
                THREAD = New Threading.Thread(AddressOf BurbujaOptimizada_Datos)
                THREAD.Start()
                Repintar(VD)
            End If
            Me.Text = "Métodos de Ordenamiento"
            Cursor = Cursors.Default
            MessageBox.Show("El vector está completamente ordenado!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '4 Burbuja Bidireccional
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdBidireccional_Click(sender As Object, e As EventArgs) Handles cmdBidireccional.Click
        If MaxValor > 0 Then
            Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
            Cursor = Cursors.WaitCursor
            If chkGraficos.Checked = True Then
                THREAD = New Threading.Thread(AddressOf BurbujaBidireccional)
                THREAD.Start()
                InicioDeBotones()
            Else
                THREAD = New Threading.Thread(AddressOf BurbujaBidireccional_Datos)
                THREAD.Start()
                Repintar(VD)
            End If
            Me.Text = "Métodos de Ordenamiento"
            Cursor = Cursors.Default
            MessageBox.Show("El vector está completamente ordenado!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '5 Selección Directa
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdDirecta_Click(sender As Object, e As EventArgs) Handles cmdDirecta.Click
        If MaxValor > 0 Then
            Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
            Cursor = Cursors.WaitCursor
            If chkGraficos.Checked = True Then
                THREAD = New Threading.Thread(AddressOf SeleccionDirecta)
                THREAD.Start()
                InicioDeBotones()
            Else
                THREAD = New Threading.Thread(AddressOf SeleccionDirecta_Datos)
                THREAD.Start()
                Repintar(VD)
            End If
            Me.Text = "Métodos de Ordenamiento"
            Cursor = Cursors.Default
            MessageBox.Show("El vector está completamente ordenado!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '6 Burbuja por Inserción
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdInsercion_Click(sender As Object, e As EventArgs) Handles cmdInsercion.Click
        If MaxValor > 0 Then
            Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
            Cursor = Cursors.WaitCursor
            If chkGraficos.Checked = True Then
                THREAD = New Threading.Thread(AddressOf BurbujaConInsercion)
                THREAD.Start()
                InicioDeBotones()
            Else
                THREAD = New Threading.Thread(AddressOf BurbujaConInsercion_Datos)
                THREAD.Start()
                Repintar(VD)
            End If
            Me.Text = "Métodos de Ordenamiento"
            Cursor = Cursors.Default
            MessageBox.Show("El vector está completamente ordenado!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '7 Merge Sort
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdMergeSort_Click(sender As Object, e As EventArgs) Handles cmdMergeSort.Click
        If MaxValor > 0 Then
            Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
            Cursor = Cursors.WaitCursor
            If chkGraficos.Checked = True Then
                THREAD = New Threading.Thread(AddressOf MergeSort)
                THREAD.Start()
                InicioDeBotones()
            Else
                THREAD = New Threading.Thread(AddressOf MergeSort_Datos)
                THREAD.Start()
                Repintar(VD)
            End If
            Me.Text = "Métodos de Ordenamiento"
            Cursor = Cursors.Default
            MessageBox.Show("El vector está completamente ordenado!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Primero necesita cargar datos en el vector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '8 Quick Sort
    '------------------------------------------------------------------------------------------------------------
    Private Sub cmdQuickSort_Click(sender As Object, e As EventArgs) Handles cmdQuickSort.Click
        If MaxValor > 0 Then
            Me.Text = "Métodos de Ordenamiento (Ordeando Vector, espere por favor...)"
            Cursor = Cursors.WaitCursor
            If chkGraficos.Checked = True Then
                THREAD = New Threading.Thread(AddressOf MetodoQuicksort)
                THREAD.Start()
                InicioDeBotones()
            Else
                THREAD = New Threading.Thread(AddressOf MetodoQuicksort_Datos)
                THREAD.Start()
                Repintar(VD)
            End If
            Me.Text = "Métodos de Ordenamiento"
            Cursor = Cursors.Default
            MessageBox.Show("El vector está completamente ordenado!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                Case Threading.ThreadState.Suspended
                    THREAD.Resume()
                    cmdPlay.BackColor = Color.Green
                Case Else
                    THREAD.Suspend()
                    cmdPlay.BackColor = Color.Gray
            End Select
        End If
    End Sub

    Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
        'En caso de que la gráfica tarde mucho tiempo cerrar el hilo y recargar el vector original
        THREAD.Suspend()
        If MessageBox.Show("Cancelar ordenamiento?" + vbLf + "Al hacerlo se cargará el vector original nuevamente", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            THREAD.Resume()
        Else
            THREAD.Resume()
            THREAD.Abort()
            V = VECTOR_INICIAL.Clone
            GraficarVector(Brushes.Blue)
            FinalDeBotones()
        End If
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
        Dim x1 As Integer, y1 As Integer, ancho As Single, alto As Single

        'Calcular proporciones y posiciones
        fph = picGrafico.Width / (UltimaPosicion + 1)
        fpv = picGrafico.Height / MaxValor

        x1 = Posic * fph
        If GraficoOno = True Then
            y1 = picGrafico.Height - (V(Posic) * fpv)
            alto = V(Posic) * fpv
        Else
            y1 = picGrafico.Height - (VD(Posic) * fpv)
            alto = VD(Posic) * fpv
        End If
        ancho = fph

        'Trazar
        Lienzo.FillRectangle(Brushes.White, x1, 0, IIf(ancho < 1, 1, ancho), picGrafico.Height)
        Lienzo.FillRectangle(ColorRelleno, x1, y1, IIf(ancho < 1, 1, ancho), alto)
    End Sub
    Private Sub GRILLA_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GRILLA.CellValueChanged
        'Cuando se dispare el evento de cambio de valor en las celdas de la grilla se hace una pequeña comprobación p/ cuando
        'los valores aun no fueren cargados

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
        '        'Recorrer vector y cambiar valor
        '       For i = 0 To UltimaPosicion - 1
        '      If VD(i) <> GRILLA.CurrentRow.Cells(0).Value Then
        '     End If
        '    Next
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

    Private Sub tbRepetidos_Scroll_1(sender As Object, e As EventArgs) Handles tbRepetidos.Scroll

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
End Class
