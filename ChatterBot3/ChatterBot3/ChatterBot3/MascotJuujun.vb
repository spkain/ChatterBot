Public Class MascotJuujun
    Inherits Mascot

    Public Sub New(ByVal aName As String)
        MyBase.New(aName)
    End Sub

    Overrides ReadOnly Property MaxListCount As Integer
        Get
            Return 10
        End Get
    End Property

    Public Overrides Sub CommandPerformBeginSay()
        MascotSay("了。")
    End Sub

    Public Overrides Sub CommandPerformEndSay()
        MascotSay("終。")
    End Sub

    Public Overrides Sub EndProcBegin()
        MascotSay("失礼。")
    End Sub

    Public Overrides Sub ErrorFullOverFlowListSay()
        MascotSay("満!")
    End Sub

    Public Overrides Sub ErrorNullSay()
        MascotSay("何!?")
    End Sub

    Public Overrides Sub ErrorZeroLearnWordSay()
        MascotSay("無!")
    End Sub

    Public Overrides Sub Hello()
        MascotSay("・・・{0}", Name)
    End Sub

    Public Overrides Sub LearnBeginSay()
        MascotSay("学始")
    End Sub

    Public Overrides Sub LearnEndSay()
        MascotSay("学終")
    End Sub

    Public Overrides Sub LearnSuccessSay()
        MascotSay("成功")
        MascotSay("残{0}", LastLearnCount)
    End Sub

    Public Overrides Sub Perform()
        MascotSay("読本")
    End Sub

    Public Overrides Sub Say()
        If (LearnCount <> 0) Then
            MascotSay("待")
            MascotSay(SelWord)
            MascotSay("完")
        End If
    End Sub
End Class
