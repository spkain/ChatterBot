Public Class MascotSeijun
    Inherits Mascot

    Public Sub New(ByVal aName As String)
        MyBase.New(aName)
    End Sub

    Public Overrides Sub CommandPerformBeginSay()
        MascotSay("えーっとまってくださいね...")
    End Sub

    Public Overrides Sub CommandPerformEndSay()
        MascotSay("おわったよー")
    End Sub

    Public Overrides Sub EndProcBegin()
        MascotSay("えーおわっちゃうんですかーToT")
    End Sub

    Public Overrides Sub ErrorFullOverFlowListSay()
        MascotSay("ごめんなさいいっぱいになっちゃったんですぅ～")
    End Sub

    Public Overrides Sub ErrorNullSay()
        MascotSay("あれ何か入れたんですか？")
        MascotSay("だめですよ？何か変なこといれたんでしょ？")
        MascotSay("けーさつにいいますよw")
    End Sub

    Public Overrides Sub ErrorZeroLearnWordSay()
        MascotSay("まだおぼえてないのでごめんなさい＞＜")
    End Sub

    Public Overrides Sub Hello()
        MascotSay("私{0}っていうんです　よろしくねっ", Name)
    End Sub

    Public Overrides Sub LearnBeginSay()
        MascotSay("教えてください！")
    End Sub

    Public Overrides Sub LearnEndSay()
        MascotSay("{0}ですね、　えっと覚えました　た、たぶん・・・", SelMaxWord)
        If LastLearnCount <> 0 Then
            MascotSay("残りはそーですね・・・{0}個いけます・・・", LastLearnCount)
        Else
            MascotSay("だ、だめー・・・もうおぼえられないよーToT")
        End If
    End Sub

    Public Overrides Sub LearnSuccessSay()

    End Sub

    Public Overrides ReadOnly Property MaxListCount As Integer
        Get
            Return 7
        End Get
    End Property

    Public Overrides Sub Perform()
        MascotSay("えっといまねー　パズド○やってます!")
    End Sub

    Public Overrides Sub Say()
        If (LearnCount <> 0) Then
            MascotSay("今日って実は、「{0}」の気分なんですよ", SelWord)
        End If
    End Sub
End Class
