### Problem

The _Snapper_ is a clever little device that, on one side, plugs its input plug into an output socket, and, on the other side, exposes an output socket for plugging in a light or other device.

When a _Snapper_ is in the ON state and is receiving power from its input plug, then the device connected to its output socket is receiving power as well. When you snap your fingers -- making a clicking sound -- any _Snapper_ receiving power at the time of the snap toggles between the ON and OFF states.

In hopes of destroying the universe by means of a singularity, I have purchased **N** _Snapper_ devices and chained them together by plugging the first one into a power socket, the second one into the first one, and so on. The light is plugged into the **N**th _Snapper_.

Initially, all the _Snapper_s are in the OFF state, so only the first one is receiving power from the socket, and the light is off. I snap my fingers once, which toggles the first _Snapper_ into the ON state and gives power to the second one. I snap my fingers again, which toggles both _Snapper_s and then promptly cuts power off from the second one, leaving it in the ON state, but with no power. I snap my fingers the third time, which toggles the first _Snapper_ again and gives power to the second one. Now both _Snapper_s are in the ON state, and if my light is plugged into the second _Snapper_ it will be _on_.

I keep doing this for hours. Will the light be _on_ or _off_ after I have snapped my fingers **K** times? The light is _on_ if and only if it's receiving power from the _Snapper_ it's plugged into.

### Input

The first line of the input gives the number of test cases, **T**. **T** lines follow. Each one contains two integers, **N** and **K**.

### Output

For each test case, output one line containing "Case #x: y", where x is the case number (starting from 1) and y is either "ON" or "OFF", indicating the state of the light bulb.

### Limits

1 ≤ **T** ≤ 10,000.

#### Small dataset

1 ≤ **N** ≤ 10;  
0 ≤ **K** ≤ 100;

#### Large dataset

1 ≤ **N** ≤ 30;  
0 ≤ **K** ≤ 10<sup>8</sup>;

### Sample

<div class="problem-io-wrapper">

<table>

<tbody>

<tr>

<td>  
<span class="io-table-header">Input</span>  
 </td>

<td>  
<span class="io-table-header">Output</span>  
 </td>

</tr>

<tr>

<td>`4  
1 0  
1 1  
4 0  
4 47  
`</td>

<td>`Case #1: OFF  
Case #2: ON  
Case #3: OFF  
Case #4: ON  

`</td>

</tr>

</tbody>

</table>

</div>