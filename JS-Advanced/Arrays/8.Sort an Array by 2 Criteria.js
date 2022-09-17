function solve(input) {
    input.sort(function (s1, s2) {
        if(s1.length > s2.length) return 1;
        if(s1.length < s2.length) return -1;
        return s1.localeCompare(s2);
    });
    console.log(input.join('\n'));
}
solve(['alpha', 
'beta', 
'gamma']
);