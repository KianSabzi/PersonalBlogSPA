import { Component, ViewEncapsulation , OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-file-manager',
  templateUrl: './file-manager.component.html',
  styleUrls: ['./file-manager.component.css']
})
export class FileManagerComponent {

  baseUrl = environment.apiUrl;
  public hostUrl: String = this.baseUrl;
  public ajaxSettings: object = {
    url: this.hostUrl + 'FileManager/FileOperations',
    getImageUrl: this.hostUrl + 'FileManager/GetImage',
    uploadUrl: this.hostUrl + 'FileManager/Upload',
    downloadUrl: this.hostUrl + 'FileManager/Download'
  };

}
