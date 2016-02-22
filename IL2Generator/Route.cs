using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plane = IL2Generator.AllPlaneDB;

namespace IL2Generator
{
    public class Route
    {
        private WaypointContainer _waypoints;
        private int idxT;
        private int NumWaypoints;


        public Route()
        {
            _waypoints = new WaypointContainer();
        }

        public WaypointContainer Waypoints
        {
            get { return _waypoints; }
            set { _waypoints = value; }
        }

        //

        private double distance(double x0, double y0, double x1, double y1)
        {  
            return  Math.Sqrt((x0-x1)*(x0-x1) + (y0-y1)*(y0-y1));
        }

        private double distancec(Coord c0, Coord c1)
        {
            return Math.Sqrt((c0.X - c1.X) * (c0.X - c1.X) + (c0.Y - c1.Y) * (c0.Y - c1.Y));
        }

        private Coord rotate(Coord v, double angle)
        {
            Coord u;
            double rad;

            rad = angle / 180 * Math.PI;

	        u.X = Math.Round(Math.Cos(rad) * v.X - Math.Sin(rad) * v.Y, -2);
	        u.Y = Math.Round(Math.Sin(rad) * v.X + Math.Cos(rad) * v.Y, -2);
            return u;
        }

        private Coord setmag(Coord v, double magnitude)
        {
            double oldmag;
            Coord u;
        
            oldmag = distance(0, 0, v.X, v.Y);

            if (v.X == 0) { v.X = 0.1;}

            if (v.Y == 0 ) {v.Y = 0.1;}

            if (oldmag == 0) {oldmag = distance(0, 0, v.X, v.Y);}

            u.X = Math.Round((v.X / oldmag) * magnitude, -2);
	        u.Y = Math.Round((v.Y / oldmag) * magnitude, -2);

            return u;
        }

        private double angle(Coord v1,Coord v2)
        {
            double ratio;

            if (v1.X == 0) v1.X = 0.1;
            if (v1.Y == 0) v1.Y = 0.1;
            if (v2.X == 0) v2.X = 0.1;
            if (v2.Y == 0) v2.Y = 0.1;

          ratio = ((v1.X * v2.X) + (v1.Y * v2.Y)) / distance(0,0,v1.X,v1.Y) / distance(0,0,v2.X,v2.Y);

          if (ratio < -1) 
          { 
              return 180;
          }
          else if (ratio > 1) { return 0;}
          else { return Math.Round(Math.Acos(ratio) / Math.PI * 180, -2);}
        }


        private int makecurve(Coord target, int seg_length, int max_angle, int max_segments,int idx)
        {
            Coord c;
            Coord v;
            Coord v1;
            Coord v2;
            double d;

            v = new Coord();

            v.X = _waypoints[idx+1].x - _waypoints[idx].x;
            v.Y = _waypoints[idx+1].y - _waypoints[idx].y;
	        v = setmag(v, seg_length);

            for (int i = idx; i < max_segments;i++)
            {
                c = new Coord();
                c.X = target.X - _waypoints[i+1].x;
                c.Y = target.Y - _waypoints[i+1].y;
                
                if (angle(v, c) < max_angle)
                {
                    v.X = target.X - _waypoints[i+1].x;
                    v.Y = target.Y - _waypoints[i+1].y;
		            v = setmag(v, seg_length);

                    //SetLength(m_WP, i+3);
                    _waypoints.Add(new Waypoint() { x = _waypoints[i + 1].x + v.X, y = _waypoints[i + 1].y + v.Y });
                    
                    return i + 3; //Success
                    
                }

                d = distance(_waypoints[i+1].x, _waypoints[i+1].y, target.X, target.Y);
                
                if (d < seg_length)
                {
                  //SetLength(m_WP, i+3);
                    _waypoints.Add(new Waypoint() { x = target.X, y = target.Y });
                    return i + 3; //Success
                }

                v1 = rotate(v, max_angle);
		        v2 = rotate(v, -max_angle);

                c.X = target.X - _waypoints[i+1].x;
                c.Y = target.Y - _waypoints[i+1].y;
                
                if (angle(v1, c) < angle(v2, c))
                {
                    v = v1; 
                }
                else 
                {
                    v = v2;
                }

                //SetLength(m_WP, i+3);
                _waypoints.Add(new Waypoint() { x = _waypoints[i + 1].x + v.X, y = _waypoints[i + 1].y + v.Y });
            }

            return max_segments;
        }

        private int makecurve(Coord target, int seg_length, int max_angle, int max_segments,int idx,WaypointContainer waypoints)
        {
            Coord c;
            Coord v;
            Coord v1;
            Coord v2;
            double d;

            v = new Coord();

            v.X = waypoints[idx+1].x - waypoints[idx].x;
            v.Y = waypoints[idx+1].y - waypoints[idx].y;
	        v = setmag(v, seg_length);

            for (int i = idx; i < max_segments;i++)
            {
                c = new Coord();
                c.X = target.X - waypoints[i+1].x;
                c.Y = target.Y - waypoints[i+1].y;
                
                if (angle(v, c) < max_angle)
                {
                    v.X = target.X - waypoints[i+1].x;
                    v.Y = target.Y - waypoints[i+1].y;
		            v = setmag(v, seg_length);

                    //SetLength(m_WP, i+3);
                    waypoints.Add(new Waypoint() { x = waypoints[i + 1].x + v.X, y = waypoints[i + 1].y + v.Y });
                    
                    return i + 3; //Success
                    
                }

                d = distance(waypoints[i+1].x, waypoints[i+1].y, target.X, target.Y);
                
                if (d < seg_length)
                {
                  //SetLength(m_WP, i+3);
                    waypoints.Add(new Waypoint() { x = target.X, y = target.Y });
                    return i + 3; //Success
                }

                v1 = rotate(v, max_angle);
		        v2 = rotate(v, -max_angle);

                c.X = target.X - waypoints[i+1].x;
                c.Y = target.Y - waypoints[i+1].y;
                
                if (angle(v1, c) < angle(v2, c))
                {
                    v = v1; 
                }
                else 
                {
                    v = v2;
                }

                //SetLength(m_WP, i+3);
                waypoints.Add(new Waypoint() { x = _waypoints[i + 1].x + v.X, y = _waypoints[i + 1].y + v.Y });
            }

            return max_segments;
        }

        private int makestraight(Coord target,int seg_length,int fin_length,int max_segments,int idx)
        {
          Coord v = new Coord();
          int i;
        
          v.X = target.X - _waypoints[idx-1].x;
          v.Y = target.Y - _waypoints[idx-1].y;
	      v = setmag (v, seg_length);

          for (i = idx;i < max_segments;i++)
          {
            if (distance(_waypoints[i-1].x, _waypoints[i-1].y, target.X, target.Y) < fin_length)
            {
              _waypoints.Add(new Waypoint(){x = target.X,y = target.Y});

              return i + 1; //Success
            }

            _waypoints.Add(new Waypoint(){x = _waypoints[i-1].x + v.X,y = _waypoints[i-1].y + v.Y});
          }

          return i;

        }


        private int land(Coord a,Coord b,Coord c,Coord d,int idx)
        {
            int waycount, i, j, k;
            WaypointContainer landcurve = new WaypointContainer();
            Coord cc = new Coord();
        
            waycount = 0;
          
            landcurve.Add(new Waypoint(){x = d.X,y = d.Y});
            landcurve.Add(new Waypoint(){x = c.X,y = c.Y});

            i = makecurve(b, 5000, 120, 10, 0, landcurve);

            waycount = waycount + i;

            _waypoints[idx].x = a.X;
            _waypoints[idx].y = a.Y;
            _waypoints[idx+1].x = b.X;
            _waypoints[idx+1].y = b.Y;

            cc.X = landcurve[i-1].x;
            cc.Y = landcurve[i-1].y;
	        j = makecurve (cc, 5000, 120, 10, idx);

            waycount = waycount + j;

            cc.X = landcurve[i-1].x;
            cc.Y = landcurve[i-1].y;
            k = makestraight(cc, 50000, 50000, 50, j);

            waycount = waycount + k - j;

            //waycpy(landcurve, i-1, k-1, true, l_WP); //ñëèâàåì äâà ìàññèâà òî÷åê
            _waypoints.AddRange(landcurve);

            return waycount;
        }


        private void InsertIntermediate()
        {
            int i, j, n;
            Coord v;
            double d;

            if ((idxT >= NumWaypoints) || (idxT < 0)) { idxT = NumWaypoints/2;}
          
            i = 0;
          
            while (i < NumWaypoints - 1)
            {
                d = distance(_waypoints[i].x, _waypoints[i].y, _waypoints[i+1].x, _waypoints[i+1].y);
                
                if (d > 10000)
                {
                  n = (int) Math.Truncate(d/10000);

			      v.X = _waypoints[i+1].x - _waypoints[i].x;
                  v.Y = _waypoints[i+1].y - _waypoints[i].y;
			      v = setmag(v, d/(n+1));
                  
                  //SetLength(WP, NumWaypoints + n); //ñäâèãàåì òî÷êè â êîíåö ìàññèâà
                    
                  for (j = NumWaypoints-1; j == i;j--)
                  {
                        _waypoints[j+n] = _waypoints[j];
                  }

                  NumWaypoints = NumWaypoints + n;
/*
                  if idxT > i then idxT := idxT + n;

                  for j := 1 to n do  //çàïîëíÿåì ïóñòûå ìåñòà ìàññèâà
                  begin
                    WP[i+j].x := WP[i+j-1].x + v.x;
                    WP[i+j].y := WP[i+j-1].y + v.y;
                    WP[i+j].wtype := 'Normfly';
                    WP[i+j].alt := 3333;
                  end;
                  i := i + n;
                }
                else i := i + 1;
          end;

          for i := 1 to NumWaypoints - 1 do //leave only legitimate IP (îñòàâëÿåì òîëüêî çàêîííûå òî÷êè)
          begin
            if WP[i].alt = 3333 then
              if (i < 3) or (i = idxT-1) or (i = idxT-2) or (i = idxT+1) or (i = idxT+2) or (i > NumWaypoints-4)
                then WP[i].alt := 333;
          end;

          for i := 1 to NumWaypoints - 1 do //óáèðàåì ëèøíèå ïðîìåæóòî÷íûå òî÷êè
          begin
            while WP[i].alt = 3333 do
            begin
              for j := i to NumWaypoints-2 do
              begin
                WP[j] := WP[j+1];
                if idxT = j+1 then idxT := j;
              end;

              if j <> i then NumWaypoints := NumWaypoints - 1;
            end;
          end;

          SetLength(WP, NumWaypoints);

          BlackboxlnP('Route.InsertIntermediate - End');
        end;


        private void AdjustAltSpeed(Plane plane,int GAidx,double CruiseAlt,bool takeoff)
        {
            int i;
            int j;
            double d;
            double a;
            double maxClimb;
            double maxDescend;
        
            Random rnd = new Random();

            maxClimb = 0.08;
            maxDescend = 0.2;

          if(plane.PlaneName.Contains("HE 111")) maxClimb = 0.05;

          if (CruiseAlt == -1) // random from minAlt up to 1.3 minAlt in hundreds
          {
            if (plane.minAlt <= 2000) 
            { 
                CruiseAlt = plane.minAlt;
            }
            else 
                if (rnd.Next(1,10) > 5) 
                {
                    CruiseAlt = plane.minAlt + rnd.Next(1,1000);
                }
                else 
                {
                    CruiseAlt = plane.minAlt - rnd.Next(1,1000);
                }
          }

          for (i = 1; i < NumWaypoints - 1;i++)
          {
            if ((_waypoints[i].x == _waypoints[i-1].x) && (_waypoints[i].y == _waypoints[i-1].y))
            {
              for (j = i;j < NumWaypoints - 2;j++)
              {
                _waypoints[j] = _waypoints[j+1];
              }

              if (j != i) NumWaypoints = NumWaypoints - 1;
            }
          }

          //SetLength(WP, NumWaypoints);
          _waypoints.Add(new Waypoint());

          InsertIntermediate();

          if GAidx <> -1 then GAidx := idxT;

          {First two points depend on ehther we start on the ground}
          if takeoff = True then
           begin
             WP[0].wtype := 'Takeoff';
		         WP[0].alt := 0;
		         WP[0].speed := 0;
		         WP[1].alt := 300;
	           WP[1].speed := 180;
	           WP[1].wtype := 'Normfly';
           end
          else
           begin
             if CruiseAlt > 1000 then WP[0].alt := 1000 else WP[0].alt := CruiseAlt;
             WP[0].speed := plane.CruiseSpeed;
             WP[0].wtype := 'Normfly';
             if CruiseAlt > 1000 then WP[1].alt := 1000 else WP[1].alt := CruiseAlt;
             WP[1].speed := plane.CruiseSpeed;
             WP[1].wtype := 'Normfly';
           end;

          for i := 2 to NumWaypoints - 2 do
          begin
            WP[i].speed := plane.CruiseSpeed;
		        if GAidx = i then WP[i].wtype := 'Gattack'  else WP[i].wtype := 'Normfly';
		        if WP[i].wtype = 'Gattack' then WP[i].alt := plane.attAlt else WP[i].alt := CruiseAlt;
          end;

          WP[NumWaypoints-1].alt := 0;
	        WP[NumWaypoints-1].speed := 0;
	        WP[NumWaypoints-1].wtype := 'Landing';

          {parameters are roughly set. Now check climb rate (ïðîâåðÿåì ïëàâíîñòü íàáîðà âûñîòû)}
          for i := 0 to NumWaypoints - 2 do
          begin
            d := distance(WP[i].x, WP[i].y, WP[i+1].x, WP[i+1].y);
            if d = 0 then d := 1;
            a := WP[i+1].alt - WP[i].alt;
            if (a > 0) and (a/d > maxClimb) then
            begin
              a := maxClimb * d;
			        WP[i+1].alt := WP[i].alt + floor(a/100)*100;
            end;
          end;

          {more important - check descend rate (ïðîâåðÿåì ïëàâíîñòü ñíèæåíèÿ)}
          for i := NumWaypoints - 1 downto 1 do
          begin
            d := distance(WP[i].x, WP[i].y, WP[i-1].x, WP[i-1].y);
            if d = 0 then d := 1;
            a := WP[i-1].alt - WP[i].alt;
            if (a > 0) and (a/d > maxDescend) then
            begin
              a := maxDescend * d;
			        WP[i-1].alt := WP[i].alt + floor(a/100)*100;
            end;
          end;

          for i := 1 to NumWaypoints - 1 do
          begin
            if (WP[i].alt < 25) and (WP[i].wtype <> 'Landing') and (WP[i].wtype <> 'Takeoff') then WP[i].alt := 100;
          end;

          BlackboxlnP('Route.AdjustAltSpeed - End');
          */
                }}}
                



        private void InterceptRoute(Route enemy, double espeed, Coord start, Coord takeoff, Coord glide, Coord landing, Coord target,Plane plane, bool gattack)
        {
            Coord c, c1, c2, v;
            int i,rounds,nr,r;
            double De, D;

            c = new Coord();
            c.X = enemy.Waypoints[0].x;
            c.Y = enemy.Waypoints[0].y;

            De = ((plane.CruiseSpeed)/espeed) * distancec(c, target);
	        D = distancec(takeoff, target);

            if (De > D) 
            {
                rounds = (int) Math.Truncate(((De - D)/20000) +1) + 1;
            }
            else 
            { 
                rounds = 5;
            }

            v = new Coord();

            v.X = c.X - target.X;
            v.Y = c.Y - target.Y;
            v = setmag(v, 10000);

            c1 = new Coord();
            c2 = new Coord();

            c1.X = target.X + v.X;
            c1.Y = target.Y + v.Y;
            v = rotate(v,120);
            

            c2.X = c1.X + v.X;
            c2.Y = c1.Y + v.Y;

            _waypoints.Add(new Waypoint() { x = start.X, y = start.Y });
            _waypoints.Add(new Waypoint() { x = takeoff.X, y = takeoff.Y });

            if (D < 10000)
            {
                _waypoints.Add(new Waypoint(){x=target.X,y = target.Y});

		        i = 3;
		        //idxT = 2;
            }
            else
            {
                r = makecurve(target, 4000, 120, 20, 0);
                i = r;

                r = makestraight(target, 50000, 50000, 50, i);

		        i = r;
		        idxT = i-1; //i is now at target waypoint (èíäåêñ òî÷êè öåëè)
            }

            for (nr = 0;nr < rounds;nr++)
            {
                _waypoints.Add(new Waypoint(){x = c1.X, y=c1.Y});
                _waypoints.Add(new Waypoint(){x = c2.X, y=c2.Y});
                _waypoints.Add(new Waypoint(){x = target.X, y = target.Y});
            }

            if (distance(glide.X, glide.Y, target.X, target.Y) < 10000)
            {
                //SetLength(WP, i + 1);
                _waypoints.Add(new Waypoint(){x = glide.X, y=glide.Y});

                i = i + 1;
                //SetLength(WP, i + 1);
                _waypoints.Add(new Waypoint(){x = landing.X, y = landing.Y});
                i = i + 1;
            }
            else
            {
                r = makecurve(glide, 5000, 120, 20, i-2);
                
                i = r-1;

                c.X = _waypoints[i-1].x;
                c.Y = _waypoints[i-1].y;

                c1.X = _waypoints[i].x;
                c1.Y = _waypoints[i].y;

                r = land(c, c1, glide, landing, i-1);
                i = r;
            }

            NumWaypoints = i;
            _waypoints[NumWaypoints-1].x = landing.X;
            _waypoints[NumWaypoints-1].y = landing.Y;

            _waypoints[NumWaypoints-2].x = glide.X;
            _waypoints[NumWaypoints-2].y = glide.Y;

            //if (gattack == true) { AdjustAltSpeed(plane, idxT, -1, true); } else { AdjustAltSpeed(plane, -1, -1, true); }

        }
    }
}
