import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input } from '@angular/core';
import { Chart, registerables } from 'chart.js';
import { SprintModel } from '../models/sprint-model';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent {
@Input() capacity: number;
@Input() velocity: number;

chart: any;

constructor(private cd: ChangeDetectorRef) {
    Chart.register(...registerables);
  }

ngOnInit(): void {
}

ngOnChanges() {
    if(this.chart) {
      this.chart.destroy();
    }
    this.createChart();
  }

createChart(){
    this.chart = new Chart("MyChart", {
      type: 'bar',
      data: {
        labels: ["Team Capacity vs Team Velocity"],
        datasets: [{
          label: 'Capacity - this sprint',
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
          ],
          data: [ this.capacity ],
          barThickness: 50,
        },
        {
          label: 'Velocity - past 3 sprints',
          backgroundColor: [
            'rgba(255, 205, 86, 0.2)',
          ],
          data: [ this.velocity ],
          barThickness: 50,
        }
      ]
      },
      options: {
        skipNull: true,
        plugins: {
          legend: {
          display: true,
          position: "right",
        }
       },
      }
    });
    this.cd.markForCheck();
  }
}
