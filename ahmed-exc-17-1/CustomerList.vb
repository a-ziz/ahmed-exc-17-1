Public Class CustomerList

    Private customers As List(Of Customer)

    Public Event Changed(customers As CustomerList)

    'New() constructor 
    Public Sub New()
        Me.customers = New List(Of Customer)
    End Sub

    ' ReadOnly Count Property
    Public ReadOnly Property Count As Integer
        Get
            Return Me.customers.Count
        End Get
    End Property

    ' Default Item(index) property
    Default Public Property Item(index As Integer) As Customer
        Get
            Return Me.customers(index)
        End Get
        Set(value As Customer)
            customers(index) = value
            RaiseEvent Changed(Me)
        End Set
    End Property

    ' Add(customer) method
    Public Sub Add(newCustomer As Customer)
        Me.customers.Add(newCustomer)
        RaiseEvent Changed(Me)
    End Sub

    ' Remove(customer) method
    Public Sub Remove(removeCustomer As Customer)
        Me.customers.Remove(removeCustomer)
        RaiseEvent Changed(Me)
    End Sub

    ' Fill() method
    Public Sub Fill()
        Me.customers = CustomerDB.GetCustomers()
        RaiseEvent Changed(Me)
    End Sub

    ' Save() method
    Public Sub Save()
        CustomerDB.SaveCustomers(Me.customers)
    End Sub

    ' +
    ' add customer
    Public Shared Operator +(c1 As CustomerList, c As Customer) As CustomerList
        c1.Add(c)
        Return c1
    End Operator

    ' -
    ' remove customer
    Public Shared Operator -(c1 As CustomerList, c As Customer) As CustomerList
        c1.Remove(c)
        Return c1
    End Operator

End Class
