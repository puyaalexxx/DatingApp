import { inject } from "@angular/core";
import { CanActivate, CanActivateFn, CanDeactivateFn } from "@angular/router";
import { AccountService } from "../_services/account.service";
import { ToastrService } from "ngx-toastr";
import { MemberEditComponent } from "../members/member-edit/member-edit.component";

export const preventUnsavedChangesGuard: CanDeactivateFn<MemberEditComponent> = (component) => {

    const accountService = inject(AccountService);
    const toastr = inject(ToastrService);

    if(component.editoForm?.dirty){
        return confirm('Are you sue you want to continue? Any unsaved changes will be lost');
    }

    return true;
}