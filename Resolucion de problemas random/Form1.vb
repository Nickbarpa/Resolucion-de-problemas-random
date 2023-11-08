Imports System

Public Class Form1
    Dim rand As New Random()
    Dim num1 As Integer
    Dim num2 As Integer
    Dim operacion As String
    Dim respuesta As Double ' Cambiado a Double para manejar divisiones con decimales

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerarProblema()
    End Sub

    Private Sub GenerarProblema()
        ' Generar dos numeros aleatorios y una operacion aleatoria
        num1 = rand.Next(1, 101)
        num2 = rand.Next(1, 101)

        Dim operacionRandom = rand.Next(4) ' Generar un numero aleatorio entre el 0 y 3

        ' Asigna la operacion segun el numero aleatorio
        Select Case operacionRandom
            Case 0
                operacion = "+"
            Case 1
                operacion = "-"
            Case 2
                operacion = "*"
            Case 3
                operacion = "/"
        End Select

        ' Muestra el problema en el lbl
        lblProblema.Text = $"{num1} {operacion} {num2} = ?"
    End Sub

    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        ' Obtiene la respuesta que se ingresa por el usuario desde el txtbox
        If Double.TryParse(txtRespuesta.Text, respuesta) Then
            ' Calcula la respuesta correcta
            Dim respuestaCorrecta As Double

            Select Case operacion
                Case "+"
                    respuestaCorrecta = num1 + num2
                Case "-"
                    respuestaCorrecta = num1 - num2
                Case "*"
                    respuestaCorrecta = num1 * num2
                Case "/"
                    ' Verificar si el divisor es cero antes de la división
                    If num2 = 0 Then
                        lblResultado.Text = "Divisor no puede ser cero."
                        Return
                    End If
                    respuestaCorrecta = num1 / num2
            End Select

            ' Verificar si la respuesta es correcta
            If respuesta = respuestaCorrecta Then
                lblResultado.Text = "¡Correcto!"
            Else
                lblResultado.Text = "Incorrecto. La respuesta es " & respuestaCorrecta
            End If

            ' Generar un nuevo problema
            GenerarProblema()

            ' Limpia el txtbox
            txtRespuesta.Clear()
        Else
            lblResultado.Text = "Por favor, ingresa un número válido."
        End If
    End Sub
End Class


