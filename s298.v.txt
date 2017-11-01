/****************************************************************************
 *                                                                          *
 *  VERILOG HIGH-LEVEL DESCRIPTION OF THE ISCAS-89 BENCHMARK CIRCUIT s298   *
 *                                                                          *
 *  Function: Traffic Light Controller                                      *
 *                                                                          *
 *  Written by: Mark C. Hansen                                              *
 *                                                                          *
 *  Last modified: Dec 05, 1997                                             *
 *                                                                          *
 *  Structural variation from gate level netlist only in that buffers are
 *  removed on primary I/O and inverters are minimized                      *
 *                                                                          *
 ****************************************************************************/

module Circuit298 (g0, g1, g2, g117, g132, g66, g118, g133, g67);

  input         g0, g1, g2;
  output        g117, g132, g66, g118, g133, g67;

  wire [2:0]    I;
  wire [1:0]    R, Y, G;
  wire          Clock;

  assign
      I[2:0] = {g2, g1, g0},
      R[1:0] = {g118, g117},
      Y[1:0] = {g133, g132},
      G[1:0] = {g67, g66};
 
      /* I[0] = Reset */
      /* I[1] = Faster Cycle */
      /* I[2] = Blink */
      /* R[1:0] = Primary:Secondary Red Light */
      /* Y[1:0] = Primary:Secondary Yellow Light */
      /* G[1:0] = Primary:Secondary Green Light */
	
  TopLevel298 Ckt298 (Clock, I, R, Y, G);

endmodule /* Circuit298 */

/*************************************************************************/

module TopLevel298 (Clock, I, R, Y, G);

  input         Clock;
  input[2:0]    I;
  output[1:0]   R, Y, G;
  wire[13:0]    Ff, FfB;
  wire          Blink, BlinkB;
  wire          I0B;

  assign R[1] = Ff[8], R[0] = Ff[9], Y[1] = Ff[10], Y[0] = Ff[11],
         G[1] = Ff[6], G[0] = Ff[7];    

  RedPrimary M1(Clock, Ff, FfB, BlinkB);
  YellowPrimary M2(Clock, Ff, FfB, Blink, BlinkB);
  GreenPrimary M3(Clock, Ff, FfB, Blink);
  RedSecondary M4(Clock, Ff, FfB, Blink, BlinkB);
  YellowSecondary M5(Clock, Ff, FfB, BlinkB);
  GreenSecondary M6(Clock, Ff, FfB, BlinkB);
  Status M7(Clock, I, I0B, Ff, FfB, Blink, BlinkB);
  Counter M8(Clock, I, I0B, Ff, FfB);
  Mode M9(Clock, I, Ff, FfB);

endmodule /* TopLevel298 */

/*************************************************************************/

module RedPrimary (Clock, Ff, FfB, BlinkB);

  input        Clock;
  inout[13:0]  Ff, FfB;
  input        BlinkB;
  wire         L116, L117, L118, L132, L103, L26;

  or L116g(L116, Ff[1], Ff[2], Ff[3], FfB[4]);
  or L117g(L117, FfB[3], Ff[8]);
  or L118g(L118, FfB[3], Ff[4]);
  nand L132g(L132, BlinkB, L116, L117, L118);
  and L103g(L103, Ff[2], Ff[4], FfB[8]);
  nor L26g(L26, L103, L132);
  DFF DFFRP(L26, Clock, Ff[8], FfB[8]);

endmodule /* RedPrimary */

/*************************************************************************/

module YellowPrimary (Clock, Ff, FfB, Blink, BlinkB);

  input        Clock;
  inout[13:0]  Ff, FfB;
  input        Blink, BlinkB;
  wire         L30, L106, L107, L108, L119, L120, L121;

  or L119g(L119, FfB[1], Ff[2], Ff[3]);
  or L120g(L120, FfB[2], Ff[10]);
  or L121g(L121, FfB[3], Ff[10]);
  nand L107g(L107, L119, L120, L121, Ff[4]);
  and L106g(L106, BlinkB, L107);
  and L108g(L108, Blink, Ff[0]);
  nor L30g(L30, L106, L108);
  DFF DFFYP(L30, Clock, Ff[10], FfB[10]);

endmodule /* YellowPrimary */

/*************************************************************************/
/*************************************************************************/

module GreenPrimary (Clock, Ff, FfB, Blink);

  input        Clock;
  inout[13:0]  Ff, FfB;
  input        Blink;
  wire         L22, L98, L99, L100;

  and L98g(L98, Ff[4], FfB[6]); 
  and L99g(L99, FfB[3], FfB[4]); 
  and L100g(L100, FfB[2], FfB[3]); 
  nor L22g(L22, Blink, L98, L99, L100);
  DFF DFFRP(L22, Clock, Ff[6], FfB[6]);

endmodule /* GreenPrimary */

/*************************************************************************/
/*************************************************************************/

module RedSecondary (Clock, Ff, FfB, Blink, BlinkB);

  input        Clock;
  inout[13:0]  Ff, FfB;
  input        Blink, BlinkB;
  wire         L28, L96, L97, L104, L105, L122, L123, L133;

  and L96g(L96, Ff[2], Ff[4], Ff[9]);
  and L97g(L97, FfB[1], FfB[2], Ff[4]);
  nor L105g(L105, L96, L97);
  and L104g(L104, BlinkB, L105, FfB[3]);
  or L122g(L122, FfB[3], FfB[4], Ff[9], Blink);
  or L123g(L123, BlinkB, FfB[0]);
  nand L133g(L133, L122, L123);
  nor L28g(L28, L104, L133);
  DFF DFFRS(L28, Clock, Ff[9], FfB[9]);

endmodule /* RedSecondary */

/*************************************************************************/
/*************************************************************************/

module YellowSecondary (Clock, Ff, FfB, BlinkB);

  input        Clock;
  inout[13:0]  Ff, FfB;
  input        BlinkB;
  wire         L32, L109, L124, L125, L126, L134;

  or L124g(L124,  FfB[3],  Ff[4]);
  or L125g(L125,  Ff[1],  Ff[4]);
  or L126g(L126, Ff[2],  Ff[3]);
  nand L134g(L134, BlinkB, L124, L125, L126);
  and L109g(L109, Ff[4], FfB[11]);
  nor L32g(L32, L109, L134); 
  DFF DFFYS(L32, Clock, Ff[11], FfB[11]);

endmodule /* YellowSecondary */

/*************************************************************************/
/*************************************************************************/

module GreenSecondary (Clock, Ff, FfB, BlinkB);

  input        Clock;
  inout[13:0]  Ff, FfB;
  input        BlinkB;
  wire         L24, L101, L102, L127, L128, L129, L131; 

  or L127g(L127, Ff[1],  Ff[2],  Ff[3],  FfB[4]); 
  or L128g(L128, FfB[1],  FfB[2],  Ff[4]); 
  or L129g(L129, FfB[2],  FfB[4],  Ff[7]);
  nand L131g(L131, BlinkB, L127, L128, L129);
  and L101g(L101, Ff[3], FfB[7]);
  and L102g(L102, Ff[3], FfB[4]);
  nor L24g(L24, L101, L102, L131);
  DFF DFFGS(L24, Clock, Ff[7], FfB[7]);

endmodule /* GreenSecondary */

/*************************************************************************/

/*************************************************************************/

module Status (Clock, I, I0B, Ff, FfB, Blink, BlinkB);

  input        Clock;
  input[2:0]   I;
  output       I0B;
  inout[13:0]  Ff, FfB;
  output       Blink, BlinkB;
  wire         L18, L20, L76, L77, L86, L87, L88;
  wire         L90, L91, L92, L93, L94, L95, L135;

  not I0Bg(I0B, I[0]);
  nor L87g(L87, FfB[3], FfB[4]);
  and L86g(L86, L87, Ff[0], FfB[1], FfB[2]);
  nand L89g(L89, Ff[0], FfB[1], FfB[2], Ff[3]);
  and L88g(L88, L89, FfB[4], FfB[13]);
  and L76g(L76, I0B, FfB[4]);
  and L77g(L77, I0B, FfB[13]);
  nor L135g(L135, L76, L77);
  nor L18g(L18, L86, L88, L135); 
  DFF DFFS1(L18, Clock, Ff[4], FfB[4]);

  nor L91g(L91, FfB[3], Ff[4]);
  nand L93g(L93, L91, FfB[1], FfB[2], Ff[12]);
  and L90g(L90, L91, Ff[1], FfB[2], FfB[12]);
  and L92g(L92, L93, FfB[5]);
  nor L20g(L20, I[0], L90, L92);
  DFF DFFS2(L20, Clock, Ff[5], FfB[5]);

  and L94g(L94, L91, Ff[1], FfB[2], FfB[12]);
  and L95g(L95, L93, FfB[5]);
  nor Blinkg(Blink, L94, L95);
  not BlinkBg(BlinkB, Blink);

endmodule /* Status */

/*************************************************************************/

/*************************************************************************/

module   Counter (Clock, I, I0B, Ff, FfB);

  /* Mod 10 Counter 0000-1001; Reset by I[0]/I0B */

  input        Clock;
  input[2:0]   I;
  input       I0B;
  inout[13:0]  Ff, FfB;
  wire L10, L12, L14, L16, L78, L79, L80, L81, L82, L83, L84, L85;
  wire L114, L115, L130;

  /*bit 0 */
  nor L10g(L10, I[0], Ff[0]);
  DFF DFFC0(L10, Clock, Ff[0], FfB[0]);

  /*bit 1 */
  and L78g(L78, Ff[0], FfB[2], Ff[3]);
  and L79g(L79, Ff[0], Ff[1]);
  and L80g(L80, FfB[0], FfB[1]);
  nor L12g(L12, I[0], L78, L79, L80);
  DFF DFFC1(L12, Clock, Ff[1], FfB[1]);

  /*bit 2 */
  and L81g(L81, Ff[0], Ff[1], Ff[2]);
  and L82g(L82, FfB[0], FfB[2]);
  and L83g(L83, FfB[1], FfB[2]);
  nor L14g(L14, I[0], L81, L82, L83);
  DFF DFFC2(L14, Clock, Ff[2], FfB[2]);

  /*bit 3 */
  nand L85g(L85, Ff[0], Ff[1], Ff[2]);
  and L84g(L84, L85, FfB[3]);
  or L114g(L114, FfB[0], FfB[1], FfB[2], FfB[3]);
  or L115g(L115, FfB[0], Ff[1], Ff[2]);
  nand L130g(L130, I0B, L114, L115);
  nor L16g(L16, L84, L130);
  DFF DFFC3(L16, Clock, Ff[3], FfB[3]);

endmodule /* Counter */

/*************************************************************************/

/*************************************************************************/

module   Mode (Clock, I, Ff, FfB);

  input        Clock;
  input[2:0]   I;
  inout[13:0]  Ff, FfB;
  wire I1B, I2B, L34, L36, L110, L111, L112, L113;

  /* Cycle Short/Long */
  not I2Bg(I2B, I[2]);
  and L110g(L110, I2B, FfB[12]);
  and L111g(L111, I[2], Ff[12]);
  nor L34g(L34, I[0], L110, L111);
  DFF DFFSpeed(L34, Clock, Ff[12], FfB[12]);

  /* Blink */
  not I1Bg(I1B, I[1]);
  and L112g(L112, I1B, FfB[13]);
  and L113g(L113, I[1], Ff[13]);
  nor L36g(L36, I[0], L112, L113);
  DFF DFFBlink(L36, Clock, Ff[13], FfB[13]);

endmodule /* Mode */

/*************************************************************************/

module DFF (D, Clock, Q, QB);

input D, Clock;
output Q, QB;
reg Q, QB;

always @(posedge Clock) begin
     #10 Q = D;
     #10 QB = ~Q;
end

endmodule /* DFF */
	
/*************************************************************************/
