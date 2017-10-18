Public Class Tours

    Private _Hotel As String = String.Empty
    Public Property Hotel As String
        Get
            Return _Hotel
        End Get
        Set(value As String)
            _Hotel = value
        End Set
    End Property

    Private _Room_Category As String = String.Empty
    Public Property Room_Category As String
        Get
            Return _Room_Category
        End Get
        Set(value As String)
            _Room_Category = value
        End Set
    End Property

    Private _Accommodation As String = String.Empty
    Public Property Accommodation As String
        Get
            Return _Accommodation
        End Get
        Set(value As String)
            _Accommodation = value
        End Set
    End Property

    Private _dateFrom As String = String.Empty
    Public Property dateFrom As String
        Get
            Return _dateFrom
        End Get
        Set(value As String)
            _dateFrom = value
        End Set
    End Property

    Private _dateTo As String = String.Empty
    Public Property dateTo As String
        Get
            Return _dateTo
        End Get
        Set(value As String)
            _dateTo = value
        End Set
    End Property

    Private _BookingFrom As String
    Public Property BookingFrom As String
        Get
            Return _BookingFrom
        End Get
        Set(value As String)
            _BookingFrom = value
        End Set
    End Property

    Private _BookingTill As String
    Public Property BookingTill As String
        Get
            Return _BookingTill
        End Get
        Set(value As String)
            _BookingTill = value
        End Set
    End Property

    Private _RO As Integer
    Public Property RO As Integer
        Get
            Return _RO
        End Get
        Set(value As Integer)
            _RO = value
        End Set
    End Property

    Private _BB As Integer = 0.0
    Public Property BB As Integer
        Get
            Return _BB
        End Get
        Set(value As Integer)
            _BB = value
        End Set
    End Property

    Private _HB As Integer
    Public Property HB As Integer
        Get
            Return _HB
        End Get
        Set(value As Integer)
            _HB = value
        End Set
    End Property

    Private _FB As Integer
    Public Property FB As Integer
        Get
            Return _FB
        End Get
        Set(value As Integer)
            _FB = value
        End Set
    End Property

    Private _All As Integer = 0.0
    Public Property All As Integer
        Get
            Return _All
        End Get
        Set(value As Integer)
            _All = value
        End Set
    End Property

    Private _StayMin As Integer
    Public Property StayMin As Integer
        Get
            Return _StayMin
        End Get
        Set(value As Integer)
            _StayMin = value
        End Set
    End Property

    Private _StayMax As Integer
    Public Property StayMax As Integer
        Get
            Return _StayMax
        End Get
        Set(value As Integer)
            _StayMax = value
        End Set
    End Property

    Private _FreeNight As Integer
    Public Property FreeNight As Integer
        Get
            Return _FreeNight
        End Get
        Set(value As Integer)
            _FreeNight = value
        End Set
    End Property

    Private _Weekdays As String
    Public Property Weekdays As String
        Get
            Return _Weekdays
        End Get
        Set(value As String)
            _Weekdays = value
        End Set
    End Property

End Class