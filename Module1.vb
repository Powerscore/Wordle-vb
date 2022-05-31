Module Module1
    Dim ArrFinal(4) As String
    Sub Main()


        Dim WList(658) As String
        Dim I As Integer = 0
        'Open text file
        Dim filereader As New IO.StreamReader("list of 100 words.txt")
        'Read file and insert to array
        While Not filereader.EndOfStream
            WList(I) = filereader.ReadLine
            I += 1
        End While
        Dim Word As String = Random(WList)
        Dim TheLength As Integer = Len(Word)
        Dim Guess As String
        Dim Tries As Integer = 0
        Do
            'Enter guess
            Do
                Console.WriteLine("Guess the " & TheLength & " lettered word")
                Guess = Console.ReadLine()
            Loop Until Len(Guess) = TheLength
            'Check guess
            Call CheckWord(Guess, Word, TheLength, ArrFinal)

            Call OutputWord()
            Console.WriteLine(6 - Tries & " tries left")
            Tries += 1
        Loop Until Tries = 6 Or UCase(Guess) = UCase(Word)
        Console.WriteLine("The word is: " & Word)
        Console.ReadLine()
    End Sub
    Function Random(ByRef Wlist() As String) As String
        Dim Rand As New Random()
        Dim Word As String
        'Generate random word
        Word = Wlist(Rand.Next(0, 658))
        Return Word
    End Function
    Sub CheckWord(ByVal Guess As String, ByVal Word As String, ByVal TheLength As Integer, ByRef ArrFinal() As String)
        Dim ArrGuess(TheLength - 1), ArrWord(TheLength - 1) As String
        'Extract letters from words
        For i = 0 To TheLength - 1
            ArrGuess(i) = Mid(UCase(Guess), i + 1, 1)
            ArrWord(i) = Mid(UCase(Word), i + 1, 1)
        Next i

        Dim Found As Boolean = False

        For i = 0 To TheLength - 1
            Found = False
            For z = 0 To TheLength - 1
                If ArrGuess(i) = ArrWord(i) Then
                    Found = True
                    ArrFinal(i) = "(" & ArrGuess(i) & ")"
                Else
                    If ArrGuess(i) = ArrWord(z) Then
                        Found = True
                        ArrFinal(i) = "<" & ArrGuess(i) & ">"

                    End If
                End If
            Next
            If Found = False Then
                ArrFinal(i) = ArrGuess(i)
            End If
        Next
        'Dim FinalWord As String = ""
        'For i = 0 To TheLength - 1
        '    FinalWord = FinalWord & ArrFinal(i)
        'Next

    End Sub
    Function CheckYellow(ByVal Letter As String, ByVal Word As String, ByVal Guess As String) As String

    End Function
    Sub OutputWord()
        For i = 0 To 4
            If Left(ArrFinal(i), 1) = "(" Then
                Console.ForegroundColor = ConsoleColor.DarkGreen
                Console.Write(Mid(ArrFinal(i), 2, 1))
                Console.ForegroundColor = ConsoleColor.White
            ElseIf Left(ArrFinal(i), 1) = "<" Then
                Console.ForegroundColor = ConsoleColor.DarkYellow
                Console.Write(Mid(ArrFinal(i), 2, 1))
                Console.ForegroundColor = ConsoleColor.White
            Else
                Console.Write(ArrFinal(i))
            End If
        Next
        Console.WriteLine()
    End Sub
End Module
'Console.ForegroundColor = ConsoleColor.DarkGreen