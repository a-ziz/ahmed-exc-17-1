Public Class frmAddCustomer

    Public Customer As Customer

    Private Sub btnSave_Click(sender As Object,
            e As EventArgs) Handles btnSave.Click
        If IsValidData() Then
            Customer = New Customer(txtFirstName.Text, txtLastName.Text, txtEmail.Text)
            Me.Close()
        End If
    End Sub

    Private Function IsValidData() As Boolean
        Return Validator.IsPresent(txtFirstName) AndAlso
               Validator.IsPresent(txtLastName) AndAlso
               Validator.IsPresent(txtEmail) AndAlso
               Validator.IsValidEmail(txtEmail)
    End Function

    Private Sub btnCancel_Click(sender As Object,
            e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class