import "strings"
func reverseWords(s string) string {
    strs := strings.Fields(s)
    var sb strings.Builder
    length := len(strs)
    for i := 0; i < length; i++ {
        sb.WriteString(strs[length - 1 - i])
        sb.WriteString(" ")
    }
    
    return strings.TrimRight(sb.String(), " ")
}
