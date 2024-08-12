import { Component, HostListener, inject, OnInit, ViewChild } from '@angular/core';
import { Member } from '../../_models/member';
import { AccountService } from '../../_services/account.service';
import { MembersService } from '../../_services/members.service';
import { FormsModule, NgForm } from '@angular/forms';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { PhotoEditorComponent } from "../photo-editor/photo-editor.component";

@Component({
  selector: 'app-member-edit',
  standalone: true,
  imports: [FormsModule, TabsModule, PhotoEditorComponent],
  templateUrl: './member-edit.component.html',
  styleUrl: './member-edit.component.css'
})
export class MemberEditComponent implements OnInit {
    @ViewChild('editForm') editoForm?: NgForm;
    @HostListener('window:beforeunload', ['$event']) notify($event: any){
      if(this.editoForm?.dirty){
        $event.returnValue = true;
      }
    }

    member? : Member;
    private accountService = inject(AccountService);
    private memberService = inject(MembersService);
    private toastr = inject(ToastrService);

    ngOnInit(): void {
      this.loadMember();
    }

    loadMember(){
      const user = this.accountService.currentUser();

      if(!user) return;

      this.memberService.getMember(user.username).subscribe({
        next: member => this.member = member
      });
    }

    updateMember(){
      this.memberService.updateMember(this.editoForm?.value).subscribe({
        next: _ => {
          this.toastr.success("Profile updated successfully");
          this.editoForm?.reset(this.member);
        }
      });
    }

    onMemberChange(event: Member){
      this.member = event;
    }

}
