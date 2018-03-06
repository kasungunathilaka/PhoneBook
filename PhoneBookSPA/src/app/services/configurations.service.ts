import { Injectable } from '@angular/core'

@Injectable()
export class ConfigurationService {
    public host_port = 'localhost:49277';
    public Server = 'http://' + this.host_port + '/';
    public ApiUrl = 'api/';
    public ServerWithApiUrl = this.Server + this.ApiUrl;
}
