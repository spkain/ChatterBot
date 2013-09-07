Public Class MascotMusin
    Inherits Mascot

    Public Sub New(ByVal aName As String)
        MyBase.New(aName)
    End Sub

    Public Overrides Sub CommandPerformBeginSay()
        ' Nothing
    End Sub

    Public Overrides Sub CommandPerformEndSay()
        ' Nothing
    End Sub

    Public Overrides Sub EndProcBegin()
        MascotSay("帰ります")
    End Sub

    Public Overrides Sub ErrorFullOverFlowListSay()
        MascotSay("理解不能です")
    End Sub

    Public Overrides Sub ErrorNullSay()
        MascotSay("何か言ったんですか？")
    End Sub

    Public Overrides Sub ErrorZeroLearnWordSay()
        MascotSay("何も覚えていませんが？")
    End Sub

    Public Overrides Sub Hello()
        MascotSay("何か言ったんですか？")
    End Sub

    Public Overrides Sub LearnBeginSay()
        MascotSay("はい、いいですよ")
    End Sub

    Public Overrides Sub LearnEndSay()
        MascotSay("終わりました")
        MascotSay("残りですか？　察してください")
    End Sub

    Public Overrides Sub LearnSuccessSay()
        MascotSay("{0}覚えましたよ", SelMaxWord)
    End Sub

    Public Overrides ReadOnly Property MaxListCount As Integer
        Get
            Return 5
        End Get
    End Property

    Public Overrides Sub Perform()
        MascotSay("読書（ラノベ）しています")
    End Sub

    Public Overrides Sub Say()
        If (LearnCount <> 0) Then
            MascotSay(SelWord)
            MascotSay("とその辺の人が言ってましたよ")
        End If
    End Sub
End Class
