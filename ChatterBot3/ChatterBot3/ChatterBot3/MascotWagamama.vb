Public Class MascotWagamama
    Inherits Mascot

    Public Sub New(ByVal aName As String)
        MyBase.New(aName)
    End Sub

    Public Overrides Sub CommandPerformBeginSay()
        'Nothing
    End Sub

    Public Overrides Sub CommandPerformEndSay()
        'Nothing
    End Sub

    Public Overrides Sub EndProcBegin()
        MascotSay("ついてこないでよね")
    End Sub

    Public Overrides Sub ErrorFullOverFlowListSay()
        ErrorNullSay()
    End Sub

    Public Overrides Sub ErrorNullSay()
        MascotSay("何かえっちぃこと言おうとしたんでしょ？")
    End Sub

    Public Overrides Sub ErrorZeroLearnWordSay()
        MascotSay("何か覚えると思った？")
    End Sub

    Public Overrides Sub Hello()
        MascotSay("あたしは、{0}っていうよ", Name)
    End Sub

    Public Overrides Sub LearnBeginSay()
        'Nothing
    End Sub

    Public Overrides Sub Learn()
        'MyBase.Learn()
        MascotSay("やだよ")
        ErrorNullSay()
    End Sub

    Public Overrides Sub LearnEndSay()
        'Nothing
    End Sub

    Public Overrides Sub LearnSuccessSay()
        'Nothing
    End Sub

    Public Overrides ReadOnly Property MaxListCount As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overrides Sub Perform()
        MascotSay("教えるわけないじゃん　べー！")
    End Sub

    Public Overrides Sub Say()
        MascotSay("何?")
    End Sub
End Class
