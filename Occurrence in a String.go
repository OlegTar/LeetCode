func strStr(haystack string, needle string) int {
    if len(needle) > len(haystack) {
        return -1
    }

    for i := 0; i < len(haystack); i++ {
        found := true;
        for j := 0; j < len(needle); j++ {
            if (i + j) >= len(haystack) || needle[j] != haystack[i + j] {
                found = false
                break
            }
        }
        if found {
            return i
        }
    }
    return -1;
}
