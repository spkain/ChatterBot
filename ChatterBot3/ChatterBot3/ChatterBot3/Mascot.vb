Imports System.Collections

Public MustInherit Class Mascot

    Const DEFAULT_NAME As String = "名無しのごんべさん"
    Private WordList As New List(Of String)
    Private FName As String
    Private rnd As New Random

    MustOverride ReadOnly Property MaxListCount As Integer

    Public ReadOnly Property LearnCount As Integer
        Get
            Return WordList.Count
        End Get
    End Property

    Public ReadOnly Property SelMaxWord As String
        Get
            Return WordList.Item(WordList.Count - 1)
        End Get
    End Property

    Overridable ReadOnly Property SelWord As String
        Get
            Return WordList.Item(rnd.Next(WordList.Count))
        End Get
    End Property

    Public ReadOnly Property LastLearnCount As Integer
        Get
            Return MaxListCount - WordList.Count
        End Get
    End Property

    Property Name As String
        Get
            Return FName
        End Get
        Set(value As String)
            If value = Nothing Or Len(value) = 0 Then
                FName = DEFAULT_NAME
            Else
                FName = value
            End If
        End Set
    End Property

    Public Enum CommandPtn As Integer
        LEARN = 0
        SAY = 1
        ACTION = 2
        ENDPROC = 3
    End Enum

    Private CommandMenu As SortedList

    Public Sub New(ByVal aName As String)
        Name = aName
        Hello()
        CommandMenu = New SortedList

        CommandMenu.Add(CommandPtn.LEARN, "学習")
        CommandMenu.Add(CommandPtn.SAY, "なんかしゃべって")
        CommandMenu.Add(CommandPtn.ACTION, "なんかして")
        CommandMenu.Add(CommandPtn.ENDPROC, "帰って")

    End Sub

    Public Sub MenuChoise()
        Console.WriteLine("メニュー：")
        Dim i As Integer

        For Each de As DictionaryEntry In CommandMenu
            Console.Write("{0}: {1}", i, de.Value)
            If i < CommandMenu.Count Then
                Console.Write(" ")
            End If
            i = i + 1
        Next

        Console.WriteLine()
        Dim cmdPtn As Integer

        Do
            Console.Write("選択肢＞")

            Try
                cmdPtn = Int32.Parse(Console.ReadLine())
            Catch
                Console.WriteLine()
                Continue Do
            End Try

            If (cmdPtn < 0 Or cmdPtn > CommandMenu.Count - 1) Then
                Console.WriteLine()
            End If
        Loop While (cmdPtn < 0 Or cmdPtn > CommandMenu.Count - 1)

        CommandPerform(cmdPtn)

    End Sub

    Public MustOverride Sub Say()

    Public Overridable Sub Learn()
        Dim learnText As String

        If WordList.Count = MaxListCount Then
            ErrorFullOverFlowListSay()
            Exit Sub
        End If

        LearnBeginSay()

        Try
            learnText = Console.ReadLine()
            If learnText = Nothing Or Len(learnText) = 0 Then
                ErrorNullSay()
                Exit Sub
            End If

        Catch
            ErrorNullSay()
            Exit Sub
        End Try

        WordList.Add(learnText)
        LearnSuccessSay()

        If MaxListCount = WordList.Count - 1 Then
            ErrorFullOverFlowListSay()
        End If

        LearnEndSay()
    End Sub

    Public Sub CommandPerform(ByRef ptn As Integer)
        CommandPerformBeginSay()

        Select Case ptn
            Case CommandPtn.LEARN
                Learn()
            Case CommandPtn.SAY
                Say()
            Case CommandPtn.ACTION
                Perform()
            Case CommandPtn.ENDPROC
                EndProc()
        End Select

        CommandPerformEndSay()
    End Sub

    Public MustOverride Sub LearnBeginSay()
    Public MustOverride Sub LearnEndSay()
    Public MustOverride Sub LearnSuccessSay()

    Public MustOverride Sub ErrorZeroLearnWordSay()
    Public MustOverride Sub ErrorFullOverFlowListSay()
    Public MustOverride Sub ErrorNullSay()
    Public MustOverride Sub CommandPerformBeginSay()
    Public MustOverride Sub CommandPerformEndSay()
    Public MustOverride Sub EndProcBegin()

    Public MustOverride Sub Hello()

    Public MustOverride Sub Perform()

    Public Sub EndProc()
        EndProcBegin()
        Environment.Exit(0)
    End Sub

    Public Sub MascotSay(ByVal mes As String)
        Console.WriteLine("{0}＞{1}", Name, mes)
    End Sub

    Public Sub MascotSay(ByVal paramtext As String, ByVal ParamArray objs() As Object)
        MascotSay(String.Format(paramtext, objs))
    End Sub

    Public Sub LineOut()
        Console.WriteLine("======================================================")
    End Sub


End Class
