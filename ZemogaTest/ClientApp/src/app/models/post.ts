import { comment } from "./comment";

export class post {
    postId : string;
    title: string;
    content: string;
    status: string;
    authorUsername: string;
    createdDate: Date;
    modifiedDate: Date;
    publishedDate: Date;
    comments : comment[]
}
