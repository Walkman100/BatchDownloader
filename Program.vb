Module Program
    Sub Main()
        ShowMenu
        
        Console.Write("Press any key to continue . . . ")
        Console.ReadKey(True)
    End Sub
    
    Sub ShowMenu()
        ' Responsive header (i.e. it'll be the width of the window)
        Dim HR As String = ""
        For i = 0 To Console.WindowWidth - 2
            HR &= "#"
        Next i
        Console.WriteLine(HR)
        
        Dim headerText = My.Application.Info.AssemblyName & " v" & My.Application.Info.Version.ToString
        Dim headerSpacing As String = ""
        For i = 0 To (Console.WindowWidth - headerText.Length)\2 -4
            headerSpacing &= " "
        Next
        
        Dim header = "##" & headerSpacing & " " & headerText
        If Console.WindowWidth Mod 2 <> 0 Then header &= " " ' check if odd width
        header &= headerSpacing & "##"
        Console.WriteLine(header)
        
        Console.WriteLine(HR)
        
        'menu algorithm
        Dim arrayToVisualise(-1) As String
        For i = 0 To 60 -1
            Array.Resize(arrayToVisualise, arrayToVisualise.Length+1)
            arrayToVisualise(i) = "this is entry number " & i & ". " & vbTab
        Next
        
        Dim selections As String = ""
        Dim columns As Integer = 1
        If Console.WindowWidth > 100 Then columns = 7
        If arrayToVisualise.Length Mod columns = 0 Then
            For i = 1 To arrayToVisualise.Length \ columns ' i is number of lines
                For j = 1 To columns ' j is current column
                    selections &= arrayToVisualise( (arrayToVisualise.Length \ columns) * (j-1) +i -1)
                    If j = columns Then selections &= vbNewLine
                Next
            Next
        Else
            For i = 1 To arrayToVisualise.Length \ columns +1 ' i is number of lines
                For j = 1 To columns ' j is current column
                    Try
                        selections &= arrayToVisualise( (arrayToVisualise.Length \ columns +1) * (j-1) +i -1)
                    Catch
                    End Try
                    If j = columns Then selections &= vbNewLine
                Next
            Next
        End If
        Console.WriteLine(selections)
    End Sub
    
    #Region "Menu Algorithm Explanation"
'		j
'1	2	3	4	5 (`columns`)
'2
'3
'4
'5
'6
'7
'
'i
'
'array(i-1)
'array.length = how many there are
'
'for i = 1 to length \ columns [amount in each column]
'    for j = 1 to columns
'        add array( (length \ columns [amount in each column] * j-1 [get current tens amount]) +i [current count] -1 [to get index])
'    next
'next
'
'
'for i = 1 to length \ columns +1 [amount in each column, one more for unevenness]
'    for j = 1 to columns
'        add array( (length \ columns +1 [see above] * j-1 [get current tens amount]) +i [current count] -1 [to get index])
'    next
'next
#End Region
    
    Sub Download(URL As String, Optional OutputFile As String = Nothing)
        If OutputFile <> Nothing Then
            Shell("wget " & URL & " -O " & OutputFile, AppWinStyle.NormalNoFocus, True, -1)
        Else
            Shell("wget " & URL, AppWinStyle.NormalNoFocus, True, -1)
        End If
    End Sub
End Module
